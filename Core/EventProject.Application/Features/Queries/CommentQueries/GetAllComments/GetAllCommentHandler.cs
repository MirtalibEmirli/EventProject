using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Comments;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public class GetAllCommentHandler : IRequestHandler<GetAllCommentRequest, GetAllCommentResponse>
{
    private readonly ICommentReadRepository _commentReadRepository;
    private readonly ICurrentUserService _currentUserService;
    public GetAllCommentHandler(ICommentReadRepository commentReadRepository,ICurrentUserService currentUserservice)
    {
        _commentReadRepository = commentReadRepository;
        _currentUserService = currentUserservice;
    }

    public async Task<GetAllCommentResponse> Handle(GetAllCommentRequest request, CancellationToken cancellationToken)
    {
        var skip = (request.Page - 1) * request.PageSize;


        var comments = _commentReadRepository.
            GetWhereQuery(c => c.EventId == request.EventId && c.IsDeleted != true && c.ParentCommentId == null)
                                             .Include(c=>c.User).Include(c=>c.User)
            .OrderByDescending(c => c.CreatedDate)
                                              .Skip(skip)
                                              
                                              .Take(request.PageSize)
                                              .ToList();
        var userId = _currentUserService.GetUserId();
        var isOwner = comments.FirstOrDefault()?.UserId == userId;

        var result = comments.Select(c => new CommentDto
        {
            Id = c.Id,
            Content = c.Content,
            CreatedDate = c.CreatedDate,
            UserName = c?.User.Lastname + " " + c?.User.Fistname,
            IsOwner = c?.UserId == userId,
            Replies = c.Replies
                .Where(r => r.IsDeleted != true)
                .Select(r => new CommentDto
                {
                    Id = r.Id,
                    Content = r.Content,
                    CreatedDate = r.CreatedDate,
                    UserName = r.User.Lastname,
                    IsOwner = r.UserId == userId // 👈 cavablarda da yoxlanır
                })
                .ToList()
        }).ToList();

        var response = new GetAllCommentResponse() { Comments = result };
        return response;
    }
}
