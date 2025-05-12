using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventCommands.UpdateEvent;
using EventProject.Application.Features.Commands.EventMediaFile.DeleteEventMedia;
using EventProject.Application.Features.Commands.EventMediaFile.UploadEventMedia;
using EventProject.Application.Features.Queries.EventQueries.GetEventById;
using EventProject.Application.Features.Queries.EventQueries.GetEventMediaFile;
using EventProject.Application.Features.Queries.EventQueries.GetEvents;
using EventProject.Application.Features.Queries.EventQueries.GetEventsForSelect;
using EventProject.Application.Features.Queries.EventQueries.GetTrending;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateEventRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("getEvents")]
    public async Task<IActionResult> GetEvents([FromQuery] GetEventsRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("uploadEventMedia")]
    public async Task<IActionResult> UploadEventMedia([FromForm] UploadEventMediaRequest request)
    {
        return Ok(await _mediator.Send(request));
    }
    [Authorize(Roles = "Admin")]
    [HttpPut]
    [Route("deleteEventMedia")]
    public async Task<IActionResult> DeleteEventMedia([FromBody] DeleteEventMediaRequest request)
    {
        var result = await _mediator.Send(request);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }


    [AllowAnonymous]
    [HttpGet("getEventMediaFiles/{eventId}")]
    public async Task<IActionResult> GetEventMediaFiles(string eventId)
    {
        var result = await _mediator.Send(new GetEventMediaFilesQuery(eventId));
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetEventByIdRequest { Id = id });

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("update_event")]
    public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventRequest updateEventRequest)
    {
        return Ok(await _mediator.Send(updateEventRequest));
    }


    [AllowAnonymous]
    [HttpGet("gettrending")]
    public async Task<IActionResult> GetTrendingEvents()
    {
        GetTrendingEventsCommand command = new();
        return Ok(await _mediator.Send(command));
    }


    [AllowAnonymous]
    [HttpGet("geteventsforselectbox")]
    public async Task<IActionResult> GetEventsForSelectBox()
    {
        var result = await _mediator.Send(new GetEventsForSelectQuery());
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }   

}


