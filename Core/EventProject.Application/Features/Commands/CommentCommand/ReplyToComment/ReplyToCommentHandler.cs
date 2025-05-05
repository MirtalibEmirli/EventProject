using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.ReplyToComment
{
    public class ReplyToCommentHandler: IRequestHandler<ReplyToCommentRequest, ResponseModel<Unit>>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReplyToCommentHandler(
            ICommentWriteRepository commentWriteRepository,
            ICommentReadRepository commentReadRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel<Unit>> Handle(ReplyToCommentRequest request, CancellationToken cancellationToken)
        {
            var parentComment = await _commentReadRepository.GetByIdAsync(request.ParentCommentId.ToString());
            if (parentComment == null)
                throw new NotFoundException("Parent comment not found");

            
            var userIdStr = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!Guid.TryParse(userIdStr, out var userId))
                throw new UnauthorizedAccessException("User not authorized");

            var reply = new Comment
            {
                Id = Guid.NewGuid(),
                Content = request.Content,
                ParentCommentId = request.ParentCommentId,
                EventId = parentComment.EventId,
                UserId = userId
            };

            await _commentWriteRepository.AddAsync(reply);
            await _commentWriteRepository.SaveChangesAsync();

            return new ResponseModel<Unit>
            {
                IsSuccess = true,
                Message = "Reply added successfully"
            };
        }
    }
}
