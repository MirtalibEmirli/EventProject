using EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;
using EventProject.Application.Features.Commands.UserMedia;
using EventProject.Application.Features.Queries.UserMediaQueries;
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
    [HttpGet("profilephoto")]
    public async Task<IActionResult> GetProfileImage()
    {
        var request = new GetUserMediaQuery();
        var response = await _sender.Send(request);

        if (!response.IsSuccess || response.Data == null)
            return NotFound(response.Message);

        return Ok(response);
    }

    [HttpGet("getrecentlyviewedevents")]
    public async Task<IActionResult> GetRwEvents()
    {
        var request = new GetRecentlyViewedEventQuery();
        return Ok(await _sender.Send(request)); 
    }
    [HttpPost
        ("profile-image")]
    public async Task<IActionResult> UploadProfile(IFormFileCollection media)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID not found.");
        }
        var request = new UploadUserMediaRequest { Media = media };
        return Ok(await _sender.Send(request));
    }   
}
