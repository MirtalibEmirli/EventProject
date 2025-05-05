using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.CommentCommand.UpdateComment
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentRequest, ResponseModel<Unit>>
    {
        private readonly ICommentWriteRepository _commentWriteRepository;
        private readonly ICommentReadRepository _commentReadRepository;

        public UpdateCommentHandler(ICommentWriteRepository commentWriteRepository,
                              ICommentReadRepository commentReadRepository)
        {
            _commentWriteRepository = commentWriteRepository;
            _commentReadRepository = commentReadRepository;
        }

        public async Task<ResponseModel<Unit>> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _commentReadRepository.GetByIdAsync(request.CommentId.ToString());
            if (comment == null || comment.IsDeleted is true)
                throw new NotFoundException("Comment not found");

            comment.Content = request.NewContent;
            comment.UpdatedDate = DateTime.Now;

            await _commentWriteRepository.SaveChangesAsync();

            return new ResponseModel<Unit>
            {
                IsSuccess = true,
                Message = "Comment updated successfully"
            };
        }
    }
}
