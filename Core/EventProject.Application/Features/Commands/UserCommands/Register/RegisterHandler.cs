using AutoMapper;
using EventProject.Application.Abstractions.Token;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Users;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Application.Services.Security;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;
using System.Security.Claims;

namespace EventProject.Application.Features.Commands.UserCommands.Register;


public class RegisterHandler(IMapper mapper, IUserReadRepsoitory userRead, IUserWriteRepository userWrite, ITokenHandler tokenHandler) : IRequestHandler<RegisterRequest, ResponseModel<RegisterResponse>>
{
    readonly IUserWriteRepository _userWrite = userWrite;
    readonly IMapper _mapper = mapper;
    readonly IUserReadRepsoitory _userReadRepsoitory = userRead;
    readonly ITokenHandler _tokenHandler = tokenHandler;
    public async Task<ResponseModel<RegisterResponse>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var exsitingUser = _userReadRepsoitory.GetWhere(u => request.Email == u.Email).FirstOrDefault();
        if (exsitingUser != null) { throw new BadRequestException($"User with email {request.Email} already exists."); }
 
        var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
        var user = _mapper.Map<User>(request);

        user.PasswordHash = hashedPassword;
        user.Role = Role.User;
        await _userWrite.AddAsync(user);
        await _userWrite.SaveChangesAsync();

        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
            new Claim(ClaimTypes.Name, user.Lastname)

        };
        var token = _tokenHandler.CreateAccessToken(claims, 160);

        return new ResponseModel<RegisterResponse>
        {
            Data = new RegisterResponse { Token = token },
            IsSuccess = true,
            Message = "User Registered SuccessFully"

        };
    }
}
