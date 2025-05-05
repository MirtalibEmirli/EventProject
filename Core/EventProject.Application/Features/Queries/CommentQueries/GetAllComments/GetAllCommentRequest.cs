using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public record GetAllCommentRequest(Guid EventId,int Page=1,int PageSize=4) :IRequest<GetAllCommentResponse>;
