using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;

public class DeleteStandingZoneRequest:IRequest<ResponseModel<bool>>
{
    public string Id { get; set; }
}
