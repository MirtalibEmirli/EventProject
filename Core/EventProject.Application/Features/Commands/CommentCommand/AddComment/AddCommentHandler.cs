using EventProject.Application.Repositories.Comments;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.AddComment;

public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
{

    private readonly ICommentWriteRepository commentWriteRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AddCommentHandler(ICommentWriteRepository commentWriteRepository, IHttpContextAccessor httpContextAccessor)
    {
        this.commentWriteRepository = commentWriteRepository;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
    {
      var httpContext=httpContextAccessor.HttpContext;
        var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value;

        if (userName is null || userId is null)
            throw new UnauthorizedAccessException("Dont found Token");

        var comment = new Comment
        {
            Content = request.Content,
            EventId = request.EventId,
            ParentCommentId = request.ParentCommentId,
            UserId = new Guid(userId),
            CreatedDate = DateTime.Now

        };
        await commentWriteRepository.AddAsync(comment);
        await commentWriteRepository.SaveChangesAsync();
        return new AddCommentResponse
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedDate,
            UserName = userName
        };
    }
}
