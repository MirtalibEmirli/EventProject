using EventProject.Application.Repositories.Seats;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsById
{
    public class DeleteSeatsByIdHandler
    : IRequestHandler<DeleteSeatsByIdRequest, DeleteSeatsByIdResponse>
    {
        private readonly ISeatWriteRepository _seatWriteRepository;
        private readonly ISeatReadRepository _seatReadRepository;

        public DeleteSeatsByIdHandler(
            ISeatWriteRepository seatWriteRepository
, ISeatReadRepository seatReadRepository)
        {
            _seatWriteRepository = seatWriteRepository;
            _seatReadRepository = seatReadRepository;
        }

        public async Task<DeleteSeatsByIdResponse> Handle(
            DeleteSeatsByIdRequest request,
            CancellationToken cancellationToken)
        {
            

           await _seatWriteRepository.SoftDeleteAsync(request.SeatId.ToString());
           await _seatWriteRepository.SaveChangesAsync();

            return new DeleteSeatsByIdResponse { IsDeleted = true };
        }
    }
}
