using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.ReplyToComment;

public class ReplyToCommentRequest:IRequest<ResponseModel<Unit>>
{
    public Guid ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;

}
