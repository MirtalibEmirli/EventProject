﻿

namespace EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;

public class GetByIdVenueResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Phone { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
