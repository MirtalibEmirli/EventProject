using EventProject.Domain.Enums;
using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;

public class CreateStandingZoneRequest:IRequest<CreateStandingZoneResponse>
{
    public string ZoneName { get; set; }
    public int Price { get; set; }  
    public int Capacity { get; set; }
    public Guid VenueId { get; set; }
    public Guid EventId { get; set; }
}
