using EventProject.Application.Repositories;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.DeleteComment;

public class DeleteCommentHandler:IRequestHandler<DeleteCommentRequest, ResponseModel<Unit>>
{
    private readonly ICommentReadRepository commentReadRepository;
    private readonly ICommentWriteRepository commentWriteRepository;

    public DeleteCommentHandler(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository)
    {
        this.commentReadRepository = commentReadRepository;
        this.commentWriteRepository = commentWriteRepository;
    }

    public async Task<ResponseModel<Unit>> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await commentReadRepository.GetByIdAsync(request.CommentId.ToString());

        if (comment is null) throw new Exception("Comment not found!");

        comment.IsDeleted = true;
        comment.DeletedDate = DateTime.Now;

        await commentWriteRepository.SaveChangesAsync();

        return new ResponseModel<Unit>
        {

            Data = Unit.Value,
            IsSuccess = true,
            Message = "Deleted Successfully"

        };

    }
}
