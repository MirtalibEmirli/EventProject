using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using EventProject.Application.Repositories.StandingZones;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;

public class CreateStandingZoneHandler : IRequestHandler<CreateStandingZoneRequest, CreateStandingZoneResponse>
{
    private readonly IStandingZoneWriteRepository standingZoneRepo;

    public CreateStandingZoneHandler(IStandingZoneWriteRepository standingZoneRepo)
    {
        this.standingZoneRepo = standingZoneRepo;
    }

    public async Task<CreateStandingZoneResponse> Handle(CreateStandingZoneRequest request, CancellationToken cancellationToken)
    {
        if (!Enum.TryParse<SZoneType>(request.ZoneName, true, out var zone))
        {
            throw new ArgumentException($"'{request.ZoneName}' zonası düzgün deyil.");
        }
        if (!Guid.TryParse(request.VenueId, out Guid venueGuid))
            throw new ArgumentException("VenueId düzgün formatda deyil");

        var standingZone = new StandingZone
        {
            Capacity = request.Capacity,
            VenueId = venueGuid,
            ZoneName = zone
        };

        await standingZoneRepo.AddAsync(standingZone);
        await standingZoneRepo.SaveChangesAsync();

        return new CreateStandingZoneResponse { Id = standingZone.Id };
    }
}
