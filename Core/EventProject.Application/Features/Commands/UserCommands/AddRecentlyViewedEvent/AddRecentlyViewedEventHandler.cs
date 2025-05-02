using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.ResponseModels;
using MediatR;

namespace EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;



public class AddRecentlyViewedEventHandler(IUserRwEventsWriteRepository userRwEventsWrite, IUserRwEventsReadRepository reeadRepo) : IRequestHandler<AddRecentlyViewedEventCommand, BaseResponseModel>
{
    private readonly IUserRwEventsWriteRepository _userRwEventsWriteRepository = userRwEventsWrite;
    private readonly IUserRwEventsReadRepository _userRwReadRepo = reeadRepo;
    public async Task<BaseResponseModel> Handle(AddRecentlyViewedEventCommand request, CancellationToken cancellationToken)
    {
        var exists = _userRwReadRepo.GetWhere(x => x.UserId == request.UserId && x.EventId == request.EventId).Any();
        if (!exists)
        {
            var isSucces = await _userRwEventsWriteRepository.AddAsync(new Domain.Entities.UserRwEvent { UserId = request.UserId, EventId = request.EventId });
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
