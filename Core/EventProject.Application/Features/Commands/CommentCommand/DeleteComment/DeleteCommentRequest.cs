using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.DeleteComment;

public class DeleteCommentRequest:IRequest<ResponseModel<Unit>>
{
    public Guid CommentId { get; set; }

}
