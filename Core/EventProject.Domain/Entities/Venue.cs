namespace EventProject.Domain.Entities;


//venue-seat =>
public class Venue:BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Description { get; set; }    
    public string Phone { get; set; } = null!;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public ICollection<VenueMediaFile> VenueMediaFiles { get; set; }
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Event> Events { get; set; }
    //qeyd-> sekil olmali


}
