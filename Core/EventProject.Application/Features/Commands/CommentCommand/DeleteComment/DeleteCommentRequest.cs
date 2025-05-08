using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.CommentCommand.DeleteComment;

public class DeleteCommentRequest:IRequest<ResponseModel<Unit>>
{
    public Guid CommentId { get; set; }

}
