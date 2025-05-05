using EventProject.Application.Features.Commands.CommentCommand.AddComment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost("{eventId}")]
        public async Task<IActionResult> AddComment(Guid eventId,AddCommentRequest comment)
        {
            comment.EventId = eventId;
            var result = await _mediator.Send(comment);
            return Ok(result);
        }

    }
}
