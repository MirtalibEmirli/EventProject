using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryHandler(ISender sender ) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateEventCategory(CreateEventCategoryRequest request)
        {
            return Ok(await sender.Send(request));
        }
    }
}
