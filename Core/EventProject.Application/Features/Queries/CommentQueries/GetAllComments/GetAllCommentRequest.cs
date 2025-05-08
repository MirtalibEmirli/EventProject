using MediatR;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public record GetAllCommentRequest(Guid EventId,int Page=1,int PageSize=4) :IRequest<GetAllCommentResponse>;
