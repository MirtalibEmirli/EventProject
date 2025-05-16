using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.ResponseModels;
using EventProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;



public class AddRecentlyViewedEventHandler(IUserRwEventsWriteRepository userRwEventsWrite, IUserRwEventsReadRepository reeadRepo, ICurrentUserService currentuserService) : IRequestHandler<AddRecentlyViewedEventCommand, BaseResponseModel>
{
    private readonly IUserRwEventsWriteRepository _userRwEventsWriteRepository = userRwEventsWrite;
    private readonly ICurrentUserService _currentUserService = currentuserService;
    private readonly IUserRwEventsReadRepository _userRwReadRepo = reeadRepo;
    public async Task<BaseResponseModel> Handle(AddRecentlyViewedEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();

        var existing = await _userRwReadRepo
            .GetWhereQuery(x => x.UserId == userId && x.EventId == request.EventId)
            .FirstOrDefaultAsync(cancellationToken);

        if (existing != null)
        {
            
            return new BaseResponseModel
            {
                IsSuccess = true,
                Message = "Event artıq mövcuddur",
                Errors = null
            };
        }

        
        await _userRwEventsWriteRepository.AddAsync(new UserRwEvent
        {
            UserId = userId,
            EventId = request.EventId,
            CreatedDate = DateTime.Now
        });

        await _userRwEventsWriteRepository.SaveChangesAsync();

        return new BaseResponseModel
        {
            IsSuccess = true,
            Message = "Event rw-yə əlavə edildi",
            Errors = null
        };

    }
}
//        {
//                "email": "mirtalibemirli498@gmail.com",
//                "password": "12345678M"
//           } 1018e283-2c0a-43c6-ddc2-08dd90c1ffad