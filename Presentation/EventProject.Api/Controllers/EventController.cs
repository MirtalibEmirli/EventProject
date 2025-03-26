using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventImageFile.UploadEventImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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


    [HttpPost("uploadImage")]
    public async Task<IActionResult> UploadEventImage([FromForm] UploadEventImageRequest request)
    {
        return Ok(await _mediator.Send(request));   
    }
}


