using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventProject.Application.Features.Commands.CommentCommand.ReplyToComment
{
    public class ReplyToCommentHandler: IRequestHandler<ReplyToCommentRequest, ResponseModel<Unit>>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;
        private readonly ICurrentUserService _currentUserService;

        public ReplyToCommentHandler(
            ICommentWriteRepository commentWriteRepository,
            ICommentReadRepository commentReadRepository,
            ICurrentUserService currentUserService)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
            _currentUserService = currentUserService;
        }

        public async Task<ResponseModel<Unit>> Handle(ReplyToCommentRequest request, CancellationToken cancellationToken)
        {
            var parentComment = await _commentReadRepository.GetByIdAsync(request.ParentCommentId.ToString());
            if (parentComment == null)
                throw new NotFoundException("Parent comment not found");

            
            var userId= _currentUserService.GetUserId();

            var reply = new Comment
            {
                Id = Guid.NewGuid(),
                Content = request.Content,
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
