using EventProject.Application.Features.Commands.SectionWeightCommand.CreateSectionWeight;
using EventProject.Application.Features.Commands.VenueCommands.CreateVenue;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionWeightController : ControllerBase
{
    private readonly IMediator _mediator;

    public SectionWeightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> CreateSectionWeight([FromForm] CreateSectionWeightRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
}
