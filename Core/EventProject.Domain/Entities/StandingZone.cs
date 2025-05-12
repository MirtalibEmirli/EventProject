using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class StandingZone:  BaseEntity 
{
    public SZoneType ZoneName { get; set; } 
    public int Capacity { get; set; }
    public int Price { get; set; }
    public Guid VenueId { get; set; }
    public Guid EventId { get; set; }
    public virtual Venue Venue { get; set; }
    public virtual Event Event { get; set; }


}
