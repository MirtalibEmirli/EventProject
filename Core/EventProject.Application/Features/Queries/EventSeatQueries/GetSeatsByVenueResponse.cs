using EventProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventSeatQueries;

public class GetSeatsByVenueResponse
{
    public List<SeatDTO> Seats { get; set; }

}
