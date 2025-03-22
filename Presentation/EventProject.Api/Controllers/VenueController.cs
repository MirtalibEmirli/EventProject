using EventProject.Application.Features.Commands.VenueCommands.CreateVenue;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IMediator _mediator;

    public VenueController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateVenue([FromBody] CreateVenueRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
}