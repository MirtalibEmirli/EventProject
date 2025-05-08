using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.UpdateStandingZone;
using EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StandingZoneController : ControllerBase
{

    private readonly IMediator _mediator;


    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStandingZoneRequest request)
    {
        var response = await _mediator.Send(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }


    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
       var response = await _mediator.Send(new GetEventStandingZoneRequest { Id = id });
        return Ok(); 
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteStandingZoneRequest { Id = id });

        if (!result)
            return NotFound(new { Message = "Standing zone not found." });

        return NoContent();
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
