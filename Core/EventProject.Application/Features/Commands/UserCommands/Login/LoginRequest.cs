using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.Login
{
    public class LoginRequest:IRequest<ResponseModel<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
