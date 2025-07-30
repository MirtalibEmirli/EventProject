using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.Repositories.UserMediaFileRepo;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Queries.CommentQueries.GetUserComments;

public class GetUserCommentsQuery : IRequest<ResponseModel<GetUserCommentsResponse>>
{
    public Guid EventId { get; set; }
}

public class GetUserCommentsHandler : IRequestHandler<GetUserCommentsQuery, ResponseModel<GetUserCommentsResponse>>
{
    private readonly ICommentReadRepository _commentReadRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserMediaFileRead _userMediaFileRead;
    public GetUserCommentsHandler(ICommentReadRepository commentReadRepository, ICurrentUserService currentUserService, IUserMediaFileRead userMediaFileRead)
    {
        _commentReadRepository = commentReadRepository;
        _currentUserService = currentUserService;
        _userMediaFileRead = userMediaFileRead; 
    }

    public async Task<ResponseModel<GetUserCommentsResponse>> Handle(GetUserCommentsQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var comments = _commentReadRepository.
            GetWhereQuery(c => c.EventId == request.EventId && c.UserId == userId).Include(c=>c.User).Include(c=>c.Replies)
            
            .ToList();
        if (comments == null)
        {
            return new ResponseModel<GetUserCommentsResponse>()
            {
                Message = $" Bu user {userId} comment edmeyib bu {request.EventId} event ucun "
                ,
                IsSuccess = true
            };
        }
        var latestMedia = _userMediaFileRead
    .GetWhere(x => x.UserId == userId && x.IsDeleted!=true
    )
    .OrderByDescending(x => x.CreatedDate)
    .FirstOrDefault();

        string? mediaUrl = latestMedia != null ? latestMedia.FileName : null;

        var commentsToFront = comments.Select(c =>
            new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                CreatedDate = c.CreatedDate,
                IsOwner=userId == c.UserId,
                UserName = c.User.Lastname+ c.User.Fistname,
                UserMediaUrl = mediaUrl,
                Replies = c.Replies.Select(r => new CommentDto
                {
                    Id = r.Id,
                    Content = r.Content,
                    CreatedDate = r.CreatedDate,
                    UserName = r.User.Lastname+r.User.Fistname,

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