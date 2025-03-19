namespace EventProject.Domain.Entities;

public class VenueImageFile:File
{

    public Guid VenueId { get; set; }
    public Venue Venue { get; set; } = null!;
}
