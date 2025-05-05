using EventProject.Application.Abstractions.Token;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Refresh;
using EventProject.Application.Repositories.Users;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Application.Services.Security;
using EventProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.Login
{

    public class LoginHandler(IUserReadRepsoitory userRead, ITokenHandler tokenHandler,IRefreshTokenWrite refreshTokenWrite) : IRequestHandler<LoginRequest, ResponseModel<LoginResponse>>
    {
        public async Task<ResponseModel<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = userRead.GetWhere(u => u.Email == request.Email).FirstOrDefault();

            if (user == null) { throw new NotFoundException($"Sistemde  {request.Email} bele mail ile qeydiyyat olunmayıb."); }


           
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
          
            if (user.PasswordHash != hashedPassword)
            {
                throw new BadRequestException($"Daxil etdiyiniz şifrə doğru deyil!");


            }
           

            List<Claim> authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()), 
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim(ClaimTypes.Name, user.Lastname)
            };
            var token = tokenHandler.CreateAccessToken(authClaims, 160);
            var refresh = tokenHandler.CreateRefreshToken();
            token.RefreshToken = refresh;
            token.RefreshTokenExpirationDate = DateTime.UtcNow.AddDays(1);

          await  refreshTokenWrite.AddAsync(new Domain.Entities.RefreshToken()
            {
                Token = refresh,    
                ExpirationDate = DateTime.UtcNow.AddDays(1),
                UserId=user.Id,

            });
            await refreshTokenWrite.SaveChangesAsync();
            var result = new LoginResponse { Token = token };
            return new ResponseModel<LoginResponse>()
            {
                Data=result,
                IsSuccess=true,
                Message="Login is Successfull"

            };

            throw new NotImplementedException();


        }
    }
}
