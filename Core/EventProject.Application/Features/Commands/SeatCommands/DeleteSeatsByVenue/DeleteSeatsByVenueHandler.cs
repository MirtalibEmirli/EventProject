using EventProject.Application.Repositories.Seats;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsByVenue;

public class DeleteSeatsByVenueHandler : IRequestHandler<DeleteSeatsByVenueRequest, DeleteSeatsByVenueResponse>
{
    private readonly ISeatWriteRepository _seatWriteRepository;
    private readonly ISeatReadRepository _seatReadRepository;
    public DeleteSeatsByVenueHandler(ISeatWriteRepository seatWriteRepository, ISeatReadRepository seatReadRepository)
    {
        _seatWriteRepository = seatWriteRepository;
        _seatReadRepository = seatReadRepository;
    }

    public async Task<DeleteSeatsByVenueResponse> Handle(DeleteSeatsByVenueRequest request, CancellationToken cancellationToken)
    {
        var seats = await _seatReadRepository
          .GetAll()
          .Where(s => s.VenueId == request.VenueId)
          .ToListAsync(cancellationToken);

        if (seats.Count == 0)
        {
            return new DeleteSeatsByVenueResponse { DeletedCount = 0 };
        }
        _seatWriteRepository.DeleteRange(seats);
       await _seatWriteRepository.SaveChangesAsync();

        return new DeleteSeatsByVenueResponse
        {
            DeletedCount = seats.Count
        };
    }
}
