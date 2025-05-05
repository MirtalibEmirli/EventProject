using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.UpdateComment;

public class UpdateCommentRequest:IRequest<ResponseModel<Unit>>
{
    public Guid CommentId { get; set; }
    public string NewContent { get; set; } = string.Empty;
}
