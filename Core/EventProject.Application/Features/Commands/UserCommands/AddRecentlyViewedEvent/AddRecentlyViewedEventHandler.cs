using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;



public class AddRecentlyViewedEventHandler(IUserRwEventsWriteRepository userRwEventsWrite, IUserRwEventsReadRepository reeadRepo, ICurrentUserService currentuserService) : IRequestHandler<AddRecentlyViewedEventCommand, BaseResponseModel>
{
    private readonly IUserRwEventsWriteRepository _userRwEventsWriteRepository = userRwEventsWrite;
    private readonly ICurrentUserService _currentUserService = currentuserService;
    private readonly IUserRwEventsReadRepository _userRwReadRepo = reeadRepo;
    public async Task<BaseResponseModel> Handle(AddRecentlyViewedEventCommand request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var exists = _userRwReadRepo.GetWhere(x => x.UserId == userId && x.EventId == request.EventId).Any();

        if (!exists)
        {
            var isSucces = await _userRwEventsWriteRepository.AddAsync(new Domain.Entities.UserRwEvent { UserId = userId, EventId = request.EventId });
            await _userRwEventsWriteRepository.SaveChangesAsync();
        }
        return new BaseResponseModel
        {
            IsSuccess = true,
            Message = "Event rw ye elave edildi",
            Errors = null
        };
    }
}
