using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace EventProject.Application.Features.Commands.UserCommands.Register
{

    public class RegisterCommand : IRequestHandler<RegisterRequest, ResponseModel<Unit>>
    {
        public Task<ResponseModel<Unit>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
