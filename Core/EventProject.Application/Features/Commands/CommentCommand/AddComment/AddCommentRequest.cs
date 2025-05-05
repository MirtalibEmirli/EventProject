using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.AddComment;

public class AddCommentRequest:IRequest<AddCommentResponse>
{

    public Guid EventId { get; set; }
    public string Content { get; set; } = string.Empty;
    public Guid? ParentCommentId { get; set; }

 
}
