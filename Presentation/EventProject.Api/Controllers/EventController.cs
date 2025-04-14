using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using EventProject.Application.Features.Commands.EventCommands.UpdateEvent;
using EventProject.Application.Features.Commands.EventMediaFile.UploadEventMedia;
using EventProject.Application.Features.Queries.EventQueries.GetEventById;
using EventProject.Application.Features.Queries.EventQueries.GetEvents;
using EventProject.Application.Features.Queries.EventQueries.GetTrending;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
//[Authorize]
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
    [HttpGet("getEvents")]
    public async Task<IActionResult> GetEvents([FromQuery] GetEventsRequest request)
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


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetEventByIdRequest { Id = id });

        if (!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPut("update_event")]
    public async Task<IActionResult> UpdateEvent([FromBody]UpdateEventRequest updateEventRequest)
    {
        return Ok(await _mediator.Send(updateEventRequest));
    }
   
    [HttpGet("gettrending")]
    public async Task<IActionResult> GetTrendingEvents()
    {
        GetTrendingEventsCommand command = new();
        return Ok(await _mediator.Send(command));
    }

}


