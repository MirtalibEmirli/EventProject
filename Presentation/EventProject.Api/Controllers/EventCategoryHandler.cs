using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;
using EventProject.Application.Features.Commands.EventCategoryCommands.UpdateEventCategory;
using EventProject.Application.Features.Queries.EventCategoryQueries.GetAllEventCategories;
using EventProject.Application.Features.Queries.EventCategoryQueries.GetEventCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class EventCategoryHandler(IMediator sender) : ControllerBase
{

    readonly IMediator _mediator = sender;

    [Authorize(Roles = "Admin")]
    [HttpPost]
    //butun add requestleri [FromForm] edmeliyik
    public async Task<IActionResult> CreateEventCategory(CreateEventCategoryRequest request)
    {
        return Ok(await sender.Send(request));
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteEventCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEventCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllEventCategoriesRequest request)
    {

        var response = await _mediator.Send(request);
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetEventCategoryByIdRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }



}
