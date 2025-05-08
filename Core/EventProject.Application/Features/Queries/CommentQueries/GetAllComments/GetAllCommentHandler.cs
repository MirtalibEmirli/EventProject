using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Comments;
using MediatR;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public class GetAllCommentHandler : IRequestHandler<GetAllCommentRequest, GetAllCommentResponse>
{
    private readonly ICommentReadRepository _commentReadRepository;

    public GetAllCommentHandler(ICommentReadRepository commentReadRepository)
    {
        _commentReadRepository = commentReadRepository;
    }

    public async Task<GetAllCommentResponse> Handle(GetAllCommentRequest request, CancellationToken cancellationToken)
    {
        var skip = (request.Page - 1) * request.PageSize;


        var comments = _commentReadRepository.GetWhere(c => c.EventId == request.EventId && c.IsDeleted != true && c.ParentCommentId == null)
                                              .OrderByDescending(c => c.CreatedDate)
                                              .Skip(skip)
                                              .Take(request.PageSize)
                                              .ToList();

        var result = comments.Select(c => new CommentDto
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
        }).ToList();
        var response = new GetAllCommentResponse() { Comments = result };
        return response;
    }
}
