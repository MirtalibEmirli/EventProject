using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.Comments;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Users;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Commands.CommentCommand.AddComment;

public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
{
    private readonly ICommentWriteRepository _commentWriteRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserReadRepsoitory _userReadRepsoitory;
    private readonly IEventReadRepository _eventReadRepository;

    public AddCommentHandler(
        ICommentWriteRepository commentWriteRepository,
        ICurrentUserService currentUserService,
        IUserReadRepsoitory userReadRepsoitory,
        IEventReadRepository eventReadRepository)
    {
        _commentWriteRepository = commentWriteRepository;
        _currentUserService = currentUserService;
        _userReadRepsoitory = userReadRepsoitory;
        _eventReadRepository = eventReadRepository;
    }

    public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();

        var eventExists = _eventReadRepository.GetWhere(e => e.Id == request.EventId).FirstOrDefault();
        var user = _userReadRepsoitory.GetWhere(u => u.Id == userId).FirstOrDefault();

        if (eventExists == null || user == null)
            throw new Exception("Event və ya User tapılmadı.");

        var comment = new Comment
        {
            Id = Guid.NewGuid(),
            Content = request.Content,
            EventId = request.EventId,
            UserId = userId,
            CreatedDate = DateTime.Now,
           
            ParentCommentId = null  
        };
        Console.WriteLine($"Creating comment: {comment.Content}, Event: {comment.EventId}, User: {comment.UserId}, Parent: {comment.ParentCommentId}");
        try
        {
            await _commentWriteRepository.AddAsync(comment);
            await _commentWriteRepository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(
                $"Xəta baş verdi: {ex.Message} \nInner: {ex.InnerException?.Message} \nStackTrace: {ex.StackTrace}");
        }

        

        return new AddCommentResponse
        {   Id = comment.Id,
            Content = comment.Content,
            CreatedAt = comment.CreatedDate,
            UserName = $"{user.Fistname} {user.Lastname}"
        };
    }
}
