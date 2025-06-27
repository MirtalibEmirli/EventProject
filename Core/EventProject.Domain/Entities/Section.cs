using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Domain.Entities
{

    public class Section
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Seat>? Seats { get; set; }
        public List<StandingZone>? StandingZones { get; set; }
        public List<Table>? Tables { get; set; }

        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }

    }
}
