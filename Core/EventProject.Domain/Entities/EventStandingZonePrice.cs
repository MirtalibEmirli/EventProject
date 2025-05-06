using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Domain.Entities;

public class EventStandingZonePrice:BaseEntity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }

    public Guid StandingZoneId { get; set; }
    public virtual StandingZone StandingZone { get; set; }

    public float Price { get; set; }

    public int AvailableCount { get; set; }
}
