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
    public  string? OpenHours { get; set; }
    public  string?  TripAdvisorLink { get; set; }
    public string? InstagramLink { get; set; }


    public virtual ICollection<VenueMediaFile> VenueMediaFiles { get; set; }
    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<StandingZone> StandingZones { get; set; }
    public virtual ICollection<Event> Events { get; set; }
    //qeyd-> sekil olmali


}
