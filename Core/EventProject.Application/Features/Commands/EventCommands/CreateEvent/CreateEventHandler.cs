using EventProject.Application.Abstractions.Storage;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

public class CreateEventHandler() : IRequestHandler<CreateEventRequest, ResponseModel<CreateEventResponse>>
{
    
    public async  Task<ResponseModel<CreateEventResponse>> Handle(CreateEventRequest request, CancellationToken cancellationToken)

    {
        //sekil elave edmek burda olmayacaq ayri endpointde olacaq amma eventcontrollerin icersinde

        throw new NotImplementedException();
    }
}
