using EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;
using EventProject.Application.Features.Queries.UserQueries.GetRecentlyViewedEvents;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventProject.Api.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{
    private readonly ISender _sender=sender;
    [HttpPost]
    public async Task<IActionResult> AddRecentlyViewedEvent(AddRecentlyViewedEventCommand request)
    {
        return Ok(await _sender.Send(request));

    }
    //4787ed36-3512-44ee-6c34-08dd869071a8
 //{70725a5f-7d98-490d-071b-08dd88a151cf}
    [HttpGet]
    public async Task<IActionResult> GetRwEvents()
    {
        var request = new GetRecentlyViewedEventQuery();
        return Ok(await _sender.Send(request)); 
    }
}
