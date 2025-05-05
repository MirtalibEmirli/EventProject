using EventProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.CommentQueries.GetAllComments;

public class GetAllCommentResponse
{
    public List<CommentDto>? Comments { get; set; }
}
