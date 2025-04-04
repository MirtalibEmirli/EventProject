using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.Register
{
    public class RegisterRequest:IRequest<ResponseModel<Unit>>
    {
    }
}
