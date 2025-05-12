using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.UpdateStandingZone;
using EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone;
using EventProject.Application.Features.Queries.EventStandingZoneQueries.GetStandingZonesAdmin;
using EventProject.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StandingZoneController : ControllerBase
{
    private readonly IMediator _mediator;

    public StandingZoneController(IMediator mediator)
    {
        _mediator = mediator;
    }

   
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStandingZoneRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }


    [AllowAnonymous]
    [HttpGet("venuestandingzones/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
       var response = await _mediator.Send(new GetEventStandingZoneRequest { VenueId = id });
        return Ok(response); 
    }

    [AllowAnonymous]
    [HttpGet("zone-types")]
    public async Task<IActionResult> GetZoneNames()
    {
        var zoneNames = Enum.GetNames(typeof(SZoneType)).ToList();
        return Ok(zoneNames);
    }

    [HttpGet("standingzonesbyevent/{id}")]
    public async Task<IActionResult> GetStandingZonesByEventId(Guid id)
    {
        var request = new GetStandingZonesByEventQuery { EventId = id };
        return Ok(await _mediator.Send(request));
    }
    [Authorize(Roles = "Admin")]
    [HttpDelete("deletestandingzone")]
    public async Task<IActionResult> Delete(DeleteStandingZoneRequest deleteRequest)
    {
        return Ok(_mediator.Send(deleteRequest));
    }

    [Authorize(Roles = "Admin")]    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateStandingZoneRequest request)
    {
        if (id != request.Id)
            return BadRequest("ID mismatch");

        var result = await _mediator.Send(request);
        return result ? NoContent() : NotFound(new { Message = "Standing zone not found." });
    }


}
