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
    [HttpPost("recentlyviewed")]
    public async Task<IActionResult> AddRecentlyViewedEvent(AddRecentlyViewedEventCommand request)
    {
        return Ok(await _sender.Send(request));

    }
     
    [HttpGet("getrecentlyviewedevents")]
    public async Task<IActionResult> GetRwEvents()
    {
        var request = new GetRecentlyViewedEventQuery();
        return Ok(await _sender.Send(request)); 
    }
}
