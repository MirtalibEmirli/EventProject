using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventCategoryHandler(IMediator sender) : ControllerBase
{

    readonly IMediator _mediator=sender;

    [HttpPost]
    public async Task<IActionResult> CreateEventCategory(CreateEventCategoryRequest request)
    {
        return Ok(await sender.Send(request));
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteEventCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok();
    }
}
