using EventProject.Application.Features.Commands.SendPartyIdeaCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PartyIdeasController : ControllerBase
{
    private readonly IMediator _mediator;

    public PartyIdeasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitIdea([FromBody] SendPartyIdeaRequest command)
    {
        var success = await _mediator.Send(command);
        if (success)
            return Ok(new { Message = "Your idea has been submitted successfully!" });

        return BadRequest(new { Message = "Failed to submit your idea. Please try again later." });
    }
}
