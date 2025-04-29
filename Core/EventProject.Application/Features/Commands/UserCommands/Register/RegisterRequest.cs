using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.Register
{
    public class RegisterRequest:IRequest<ResponseModel<RegisterResponse>>
    {

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
