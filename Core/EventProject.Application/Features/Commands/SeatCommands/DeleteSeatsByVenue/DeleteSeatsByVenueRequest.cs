using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.SeatCommands.DeleteSeatsByVenue;

public class DeleteSeatsByVenueRequest : IRequest<DeleteSeatsByVenueResponse>
{
    public Guid VenueId { get; set; }
 
}