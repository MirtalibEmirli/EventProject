using EventProject.Application.Repositories.StandingZones;
using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone;

public class DeleteStandingZoneHandler : IRequestHandler<DeleteStandingZoneRequest, bool>
{
    private readonly IStandingZoneWriteRepository standingZoneWriteRepository;

    private readonly IStandingZoneReadRepository standingZoneReadRepository;

    public DeleteStandingZoneHandler(IStandingZoneWriteRepository standingZoneWriteRepository, IStandingZoneReadRepository standingZoneReadRepository)
    {
        this.standingZoneWriteRepository = standingZoneWriteRepository;
        this.standingZoneReadRepository = standingZoneReadRepository;
    }

    public async Task<bool> Handle(DeleteStandingZoneRequest request, CancellationToken cancellationToken)
    {
        var zone = await standingZoneReadRepository.GetByIdAsync(request.Id);
        if(zone == null) return false;
        await standingZoneWriteRepository.SoftDeleteAsync(request.Id);
        await standingZoneWriteRepository.SaveChangesAsync();
        return true;
    }
}
