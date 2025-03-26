using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventMediaFile.UploadEventMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }


    [HttpPost("uploadEventMedia")]
    public async Task<IActionResult> UploadEventMedia([FromForm] UploadEventMediaRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
}


