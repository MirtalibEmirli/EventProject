using EventProject.Application.Abstractions.Token;
using EventProject.Application.DTOs;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Refresh;
using EventProject.Application.Repositories.Users;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.RefreshToken;

public class RefreshTokenRequest:IRequest<ResponseModel<Token>>
{
    public string RefreshToken { get; set; }
}

public class RefreshTokenHanlder(IRefreshTokenWrite refreshTokenWrite,IRefreshTokenRead refreshTokenRead,IUserReadRepsoitory userReadRepsoitory,ITokenHandler tokenHandler) : IRequestHandler<RefreshTokenRequest, ResponseModel<Token>>
{
    public async Task<ResponseModel<Token>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.RefreshToken token = refreshTokenRead.GetWhere(x => x.Token == request.RefreshToken).FirstOrDefault()!;
        if (token == null || token.ExpirationDate < DateTime.Now) { throw new BadRequestException("Refresh token etibarsız və ya vaxtı keçmişdir."); }

        var user = userReadRepsoitory.GetWhere(x => x.Id == token.UserId).FirstOrDefault();
        if (user == null) { throw new NotFoundException("Istifadəçi tapılmadı."); }

        List<Claim> claims = new List<Claim>()
        {
           new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
            new Claim(ClaimTypes.Name, user.Lastname)
        };

        var newAccessToken = tokenHandler.CreateAccessToken(claims, 160);
        newAccessToken.RefreshToken = tokenHandler.CreateRefreshToken();
        newAccessToken.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(1);
        await refreshTokenWrite.SoftDeleteAsync(token.Id.ToString());
        await refreshTokenWrite.AddAsync(new Domain.Entities.RefreshToken()
        {
            Token = newAccessToken.RefreshToken,
            UserId = user.Id,
            ExpirationDate = DateTime.UtcNow.AddDays(1)
        });
        await refreshTokenWrite.SaveChangesAsync();

        return new ResponseModel<Token> { Data = newAccessToken, IsSuccess = true };
    }
}
