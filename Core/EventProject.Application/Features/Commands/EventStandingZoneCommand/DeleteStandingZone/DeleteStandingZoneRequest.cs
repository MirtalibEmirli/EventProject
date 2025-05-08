using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;

public class DeleteStandingZoneRequest:IRequest<bool>
{
    public string Id { get; set; }
}
