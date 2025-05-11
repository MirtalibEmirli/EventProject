using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsById
{
    public class DeleteSeatsByIdRequest : IRequest<DeleteSeatsByIdResponse>
    {
        public Guid SeatId { get; set; }

      
    }
}
