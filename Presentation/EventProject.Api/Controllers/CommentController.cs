using EventProject.Application.Features.Commands.CommentCommand.AddComment;
using EventProject.Application.Features.Commands.CommentCommand.DeleteComment;
using EventProject.Application.Features.Commands.CommentCommand.ReplyToComment;
using EventProject.Application.Features.Commands.CommentCommand.UpdateComment;
using EventProject.Application.Features.Queries.CommentQueries.GetAllComments;
using EventProject.Application.Features.Queries.CommentQueries.GetUserComments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventProject.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;
    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    //fronta gore duzeld
    [Authorize]
    [HttpPost("{eventId}")]
    public async Task<IActionResult> AddComment(Guid eventId,AddCommentRequest comment)
    {
        comment.EventId = eventId;
        var result = await _mediator.Send(comment);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetComments(Guid eventId, int page = 1, int pageSize = 4)
    {
            var result = await _mediator.Send(new GetAllCommentRequest(eventId, page, pageSize));
        return Ok(result);
    }

    [Authorize]
    [HttpGet("usercomments/{eventId}")]
    public async Task<IActionResult> GetUserComments(Guid eventId)
    {
        var result = await _mediator.Send(new GetUserCommentsQuery() { EventId = eventId });
        return Ok(result);
    }

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        var result = await _mediator.Send(new DeleteCommentRequest() { CommentId=id});
        return Ok(result);
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [Authorize]
    [HttpPost("reply")]
    public async Task<IActionResult> ReplyToComment([FromBody] ReplyToCommentRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
