using EventProject.Application.DTOs;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR; 

namespace EventProject.Application.Features.Commands.VenueCommands.CreateVenue;

public class CreateVenueRequest : IRequest<ResponseModel<Guid>>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string? Description { get; set; }
    public string Phone { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string? OpenHours { get; set; }
    public string? TripAdvisorLink { get; set; }
    public string? InstagramLink { get; set; }
}


