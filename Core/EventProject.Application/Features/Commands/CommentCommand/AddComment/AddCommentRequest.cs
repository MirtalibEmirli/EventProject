using MediatR;

namespace EventProject.Application.Features.Commands.CommentCommand.AddComment;

public class AddCommentRequest:IRequest<AddCommentResponse>
{

    public Guid EventId { get; set; }
    public string Content { get; set; } = string.Empty;
 
}
