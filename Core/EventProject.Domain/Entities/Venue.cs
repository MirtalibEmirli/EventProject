namespace EventProject.Domain.Entities;

public class Venue:BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Description { get; set; }    
    public string Phone { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public ICollection<VenueImageFile> VenueImages { get; set; }

    //qeyd-> sekil olmali


}
