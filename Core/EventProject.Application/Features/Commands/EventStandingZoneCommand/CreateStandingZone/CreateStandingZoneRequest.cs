using EventProject.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;

public class CreateStandingZoneRequest:IRequest<CreateStandingZoneResponse>
{
    public string ZoneName { get; set; } 
    public int Capacity { get; set; }
    public string VenueId { get; set; }
}
