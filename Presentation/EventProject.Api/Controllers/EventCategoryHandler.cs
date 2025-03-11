using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;
using EventProject.Application.Features.Commands.EventCategoryCommands.UpdateEventCategory;
using EventProject.Application.Features.Queries.EventCategoryQueries.GetAllEventCategories;
using EventProject.Application.Features.Queries.EventCategoryQueries.GetEventCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventCategoryHandler(IMediator sender) : ControllerBase
{

    readonly IMediator _mediator = sender;

    [HttpPost]
    //butun add requestleri [FromForm] edmeliyik
    public async Task<IActionResult> CreateEventCategory(CreateEventCategoryRequest request)
    {
        return Ok(await sender.Send(request));
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteEventCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEventCategoryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllEventCategoriesRequest request)
    {

        var response = await _mediator.Send(request);
        return Ok(response);
    }

	[HttpGet("{Id}")]
	public async Task<IActionResult> GetById([FromRoute] GetEventCategoryByIdRequest request)
    {
		var response = await _mediator.Send(request);
		return Ok(response);
	}



}
