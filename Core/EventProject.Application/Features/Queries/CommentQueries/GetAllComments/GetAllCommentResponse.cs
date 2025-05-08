using EventProject.Application.DTOs;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public class GetAllCommentResponse
{
    public List<CommentDto>? Comments { get; set; }
}
