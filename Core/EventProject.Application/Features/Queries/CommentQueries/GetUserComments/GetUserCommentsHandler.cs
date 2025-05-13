using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.CommentQueries.GetUserComments;

public class GetUserCommentsQuery : IRequest<ResponseModel<GetUserCommentsResponse>>
{
    public Guid EventId { get; set; }
}

public class GetUserCommentsHandler : IRequestHandler<GetUserCommentsQuery, ResponseModel<GetUserCommentsResponse>>
{
    private readonly ICommentReadRepository _commentReadRepository;
    private readonly ICurrentUserService _currentUserService;

    public GetUserCommentsHandler(ICommentReadRepository commentReadRepository, ICurrentUserService currentUserService)
    {
        _commentReadRepository = commentReadRepository;
        _currentUserService = currentUserService;
    }

    public async Task<ResponseModel<GetUserCommentsResponse>> Handle(GetUserCommentsQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var comments = _commentReadRepository.GetWhere(c => c.EventId == request.EventId && c.UserId == userId).ToList();
        if (comments == null)
        {
            return new ResponseModel<GetUserCommentsResponse>()
            {
                Message = $" Bu user {userId} comment edmeyib bu {request.EventId} event ucun "
                ,
                IsSuccess = true
            };
        }

        var commentsToFront = comments.Select(c =>
            new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                CreatedDate = c.CreatedDate,
                UserName = c.User.Lastname,
                Replies = c.Replies.Select(r => new CommentDto
                {
                    Id = r.Id,
                    Content = r.Content,
                    CreatedDate = r.CreatedDate,
                    UserName = r.User.Lastname
                }).ToList()

            }
        ).ToList();

        return new ResponseModel<GetUserCommentsResponse>
        {
            Message = "User comments",
            IsSuccess = true,
            Data = new GetUserCommentsResponse()
            {
                Comments = commentsToFront
            }
        };
    }
}

public class GetUserCommentsResponse
{
    public List<CommentDto> Comments { get; set; }
}