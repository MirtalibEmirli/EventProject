namespace EventProject.Domain.Entities;

public class SectionWeight:BaseEntity
{
    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;

    public string SectionName { get; set; } = null!;
    public float Weight { get; set; }
}
 