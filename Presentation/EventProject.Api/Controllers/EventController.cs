using EventProject.Application.Features.Commands.EventCommands.CreateEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IMediator sender) : ControllerBase
{
      readonly IMediator _sender =sender;

}

