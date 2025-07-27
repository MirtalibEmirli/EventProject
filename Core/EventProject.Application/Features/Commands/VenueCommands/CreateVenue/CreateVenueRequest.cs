using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.VenueCommands.CreateVenue;

public class CreateVenueRequest : IRequest<ResponseModel<Guid>>
{
    public required string Name { get; set; }
    public  required string Address { get; set; }
    public string? Description { get; set; }

    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public required string Phone { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

 
    public string? TripAdvisorLink { get; set; }
    public string? InstagramLink { get; set; }
}






//{
//  "name": "test",
//  "address": "test",
//  "description": "test",
//  "openTime": "11:59:00",
//  "closeTime": "23:59:00",
//  "phone": "string",
//  "latitude": 40,
//  "longitude": 40,
//  "tripAdvisorLink": "test",
//  "instagramLink": "test"
//}