using EventProject.Application.DTOs;
using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventSeatPriceCommand;
using EventProject.Persistence.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSeatPriceController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly  AppDbContext _context;
        public EventSeatPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateEventSeatPriceRequest request)
        {
            var result = await _mediator.Send(request);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{eventId}/seat-prices")]
        public async Task<IActionResult> GetSeatPrices(Guid eventId)
        {
            var seatPrices = await _context.EventSeatPrices
                .Where(x => x.EventId == eventId)
                .GroupBy(x => new { x.Seat.Section, x.Price })
                .Select(g => new SeatPriceDTO
                {
                    Section = g.Key.Section,
                    Price = g.Key.Price,
                    Available = g.Count()
                })
                .ToListAsync();

            return Ok(seatPrices);
        }
    }
}
