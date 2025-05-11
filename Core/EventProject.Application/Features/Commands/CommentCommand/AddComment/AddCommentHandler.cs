using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.Repositories.Users;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.CommentCommand.AddComment;

public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
{

    private readonly ICommentWriteRepository _commentWriteRepository;
    private readonly ICurrentUserService _currentUserService;

    private readonly IUserReadRepsoitory _userReadRepsoitory;

    public AddCommentHandler(ICommentWriteRepository commentWriteRepository, ICurrentUserService currentUserService, IUserReadRepsoitory userReadRepsoitory)
    {
        _commentWriteRepository = commentWriteRepository;
        _currentUserService = currentUserService;
        _userReadRepsoitory = userReadRepsoitory;
    }

    public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var user = await _userReadRepsoitory.GetByIdAsync(userId.ToString());
        var comment = new Comment
        {
            Content = request.Content,
            EventId = request.EventId,
            UserId = userId,
            CreatedDate = DateTime.Now

        };
        await _commentWriteRepository.AddAsync(comment);
        await _commentWriteRepository.SaveChangesAsync();

        return new AddCommentResponse
        {
            Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedDate,
            UserName = user.Fistname + " " + user.Lastname,
        };
    }
}
