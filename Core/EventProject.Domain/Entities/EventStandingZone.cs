using EventProject.Domain.Entities;

public class EventStandingZone : BaseEntity
{
    public Guid EventId { get; set; }
    public virtual Event Event { get; set; }

    public Guid StandingZoneId { get; set; }
    public virtual StandingZone StandingZone { get; set; }

    public float Price { get; set; }
}
