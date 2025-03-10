using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCommands.CreateEvent;

public class CreateEventHandler : IRequestHandler<CreateEventRequest, ResponseModel<CreateEventResponse>>
{
    public Task<ResponseModel<CreateEventResponse>> Handle(CreateEventRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
