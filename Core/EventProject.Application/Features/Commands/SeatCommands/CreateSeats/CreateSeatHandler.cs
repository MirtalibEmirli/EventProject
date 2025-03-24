using EventProject.Application.Repositories.Seats;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace EventProject.Application.Features.Commands.SeatCommands.CreateSeats;

public class CreateSeatHandler : IRequestHandler<CreateSeatRequest, ResponseModel<Unit>>
{
    private readonly ISeatWriteRepository seatWriteRepository;

    public CreateSeatHandler(ISeatWriteRepository seatWriteRepository)
    {
        this.seatWriteRepository = seatWriteRepository;
    }

    public async Task<ResponseModel<Unit>> Handle(CreateSeatRequest request, CancellationToken cancellationToken)
    {
        using var reader = new StreamReader(request.File.OpenReadStream(),Encoding.UTF8);
        var json = await reader.ReadToEndAsync(cancellationToken);
        var seats = JsonConvert.DeserializeObject<List<Seat>>(json);

        if(seats is null || !seats.Any() )
            return new ResponseModel<Unit>(new List<string> { "JSON faylı boşdur və ya format yanlışdır." });

        foreach (var seat in seats)
        {
            seat.VenueId = request.VenueId;
        }

        await seatWriteRepository.AddRangeAsync(seats);
        await seatWriteRepository.SaveChangesAsync();

        return new ResponseModel<Unit>{
            IsSuccess = true,
            Data = Unit.Value
        };
    }
}
