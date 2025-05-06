using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone
{
    public class GetEventStandingZoneResponse
    {
        public Guid Id { get; set; }
        public string ZoneName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public Guid VenueId { get; set; }
    }
}
