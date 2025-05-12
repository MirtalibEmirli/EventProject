using EventProject.Application.Repositories.StandingZones;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;

public class DeleteStandingZoneHandler : IRequestHandler<DeleteStandingZoneRequest, ResponseModel<bool>>
{
    private readonly IStandingZoneWriteRepository standingZoneWriteRepository;

    private readonly IStandingZoneReadRepository standingZoneReadRepository;

    public DeleteStandingZoneHandler(IStandingZoneWriteRepository standingZoneWriteRepository, IStandingZoneReadRepository standingZoneReadRepository)
    {
        this.standingZoneWriteRepository = standingZoneWriteRepository;
        this.standingZoneReadRepository = standingZoneReadRepository;
    }

    public async Task<ResponseModel<bool>> Handle(DeleteStandingZoneRequest request, CancellationToken cancellationToken)
    {
        var zone = await standingZoneReadRepository.GetByIdAsync(request.Id);
        if (zone == null) return new ResponseModel<bool>
        {
            IsSuccess = false,
            Message = "Standing zone not deleted  .",
            Data = true
        }; ;
        await standingZoneWriteRepository.SoftDeleteAsync(request.Id);
        await standingZoneWriteRepository.SaveChangesAsync();
        return new ResponseModel<bool>
        {
            IsSuccess = true,
            Message = "Standing zone deleted successfully.",
            Data = true
        };
    }
}
