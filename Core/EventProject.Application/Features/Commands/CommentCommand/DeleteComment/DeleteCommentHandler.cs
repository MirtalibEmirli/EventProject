using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.CommentCommand.DeleteComment;

public class DeleteCommentHandler:IRequestHandler<DeleteCommentRequest, ResponseModel<Unit>>
{
    private readonly ICommentReadRepository commentReadRepository;
    private readonly ICommentWriteRepository commentWriteRepository;
    private readonly     ICurrentUserService _currentUserService;

    public DeleteCommentHandler(ICommentReadRepository commentReadRepository, ICommentWriteRepository commentWriteRepository,ICurrentUserService currentUserService)
    {
        this.commentReadRepository = commentReadRepository;
        this.commentWriteRepository = commentWriteRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ResponseModel<Unit>> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await commentReadRepository.GetByIdAsync(request.CommentId.ToString());

        if (comment is null) throw new Exception("Comment not found!");
        var userId = _currentUserService.GetUserId();   
        var userRole = _currentUserService.GetRole();
        if (comment.UserId != userId || userRole != "Admin")
        {
            return new ResponseModel<Unit>
            {
                IsSuccess = false,
                Message = "Siz bu kommenti silə bilmərsiniz!"
            };
        }


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
