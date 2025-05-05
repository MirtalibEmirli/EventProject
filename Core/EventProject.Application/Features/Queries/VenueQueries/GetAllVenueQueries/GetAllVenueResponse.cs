using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;

public class GetAllVenueResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Phone { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string> MediaUrls { get; set; }

    public string? OpenHours { get; set; }
    public string? TripAdvisorLink { get; set; }
    public string? InstagramLink { get; set; }
}
