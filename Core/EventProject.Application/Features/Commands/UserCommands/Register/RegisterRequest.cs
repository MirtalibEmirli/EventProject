using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.UserCommands.Register;

public class RegisterRequest:IRequest<ResponseModel<RegisterResponse>>
{
    
    public string Fistname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
