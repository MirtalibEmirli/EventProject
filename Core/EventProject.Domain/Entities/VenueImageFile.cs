namespace EventProject.Domain.Entities;

public class VenueMediaFile:File 
{

    public Guid VenueId { get; set; }
    public virtual Venue Venue { get; set; } = null!;
}
