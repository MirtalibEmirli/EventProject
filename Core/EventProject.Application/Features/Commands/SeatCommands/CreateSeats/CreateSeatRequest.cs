

using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.SeatCommands.CreateSeats;

public class CreateSeatRequest:IRequest<ResponseModel<Unit>>
{
    public Guid VenueId { get; set; }
    public IFormFile File { get; set; } = null!;
}
