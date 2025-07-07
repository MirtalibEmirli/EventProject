using EventProject.Application.Features.Commands.EventCommands.CreateSection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController(ISender sender) : ControllerBase
    {



        [HttpPost]
        public async Task<IActionResult> AddSection(CreateSectionRequest createSectionRequest)
        {
           return Ok(await sender.Send(createSectionRequest));  
        }
    }
}
