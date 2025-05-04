using EventProject.Application.Features.Commands.UserCommands.Login;
using EventProject.Application.Features.Commands.UserCommands.RefreshToken;
using EventProject.Application.Features.Commands.UserCommands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AuthController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        return Ok(await _sender.Send(request));
    }
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenRequest request)
    {
        return Ok(await _sender.Send(request));
    }

}
