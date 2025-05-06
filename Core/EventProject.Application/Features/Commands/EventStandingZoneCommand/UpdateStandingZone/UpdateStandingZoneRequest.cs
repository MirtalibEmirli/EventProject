using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.UpdateStandingZone;

public class UpdateStandingZoneRequest:IRequest<bool>
{
    public Guid Id { get; set; }
    public string ZoneName { get; set; } = null!;
    public int Capacity { get; set; }
    public Guid VenueId { get; set; }
}
