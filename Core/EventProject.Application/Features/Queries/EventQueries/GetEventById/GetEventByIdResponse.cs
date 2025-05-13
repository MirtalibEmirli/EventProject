using EventProject.Application.DTOs;
using EventProject.Domain.Entities;

namespace EventProject.Application.Features.Queries.EventQueries.GetEventById;

public class GetEventByIdResponse
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int AgeLimit { get; set; }
    public float MinPrice { get; set; }
    public float MaxPrice { get; set; }

    public string VenueName { get; set; } = string.Empty;
    public string VenueAddress { get; set; } = string.Empty;

    public string CategoryName { get; set; } = string.Empty;

    public List<string> MediaUrls { get; set; } = new();

    public List<SeatDTO> Seats { get; set; } = new();
    //public List<StandingZone>? StandingZones { get; set; } = new();                      

}
