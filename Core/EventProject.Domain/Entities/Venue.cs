using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventProject.Domain.Entities;

public class Venue : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    [Phone]
    public string Phone { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    //time only
    public string? TripAdvisorLink { get; set; }

    public string? InstagramLink { get; set; }

    // Navigations


    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<VenueMediaFile> VenueMediaFiles { get; set; } = new List<VenueMediaFile>();
}
