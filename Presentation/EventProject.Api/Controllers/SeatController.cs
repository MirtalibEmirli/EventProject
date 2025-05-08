using EventProject.Application.Features.Commands.SeatCommands;
using EventProject.Application.Features.Commands.SeatCommands.CreateSeats;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Authorize] 
[Route("api/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly IMediator _mediator;

    public SeatController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [Authorize(Roles = "Admin")]    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadSeats([FromForm] CreateSeatRequest request)
    {
        var response = await _mediator.Send(request);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
}
