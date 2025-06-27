using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class StandingZone : BaseEntity
{
    public string ZoneName { get; set; } = null!;

    public int Capacity { get; set; }

    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;

    public Guid SectionId { get; set; }
    public virtual Section Section { get; set; } = null!;

    public virtual ICollection<EventStandingZone> EventStandingZones { get; set; } = new List<EventStandingZone>();
}
