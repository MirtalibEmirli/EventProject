using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventSeatPriceCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventSeatPriceController : ControllerBase
    {

        private readonly IMediator _mediator;

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
    }
}
