using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IMediator sender) : ControllerBase
{
    readonly IMediator _sender = sender;

    [HttpPost]

    public async Task<IActionResult> AddEvent(CreateEventRequest request)
    {
        return Ok(await _sender.Send(request));
    }

    //[HttpPost("[action]")]
    //[Authorize(AuthenticationSchemes = "Admin")]
    //[AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
    //public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
    //{
    //    uploadProductImageCommandRequest.Files = Request.Form.Files;
    //    UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
    //    return Ok();
    //}

}

