using EventProject.Application.Exceptions;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using EventProject.Application.Repositories.StandingZones;
using EventProject.Application.Repositories.Venues;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;

public class CreateStandingZoneHandler : IRequestHandler<CreateStandingZoneRequest, CreateStandingZoneResponse>
{
    private readonly IStandingZoneWriteRepository standingZoneRepo;
    private readonly IVenueReadRepository venueReadRepo;
    public CreateStandingZoneHandler(IStandingZoneWriteRepository standingZoneRepo, IVenueReadRepository venueReadRepo)
    {
        this.standingZoneRepo = standingZoneRepo;
        this.venueReadRepo = venueReadRepo;
    }

    public async Task<CreateStandingZoneResponse> Handle(CreateStandingZoneRequest request, CancellationToken cancellationToken)
    {
      
        var venue = await venueReadRepo.GetByIdAsync(request.VenueId.ToString());
        if (venue is null)
            throw new NotFoundException("Venue tapilmadi");

        var standingZone = new StandingZone
        {
            Capacity = request.Capacity,
            VenueId = venue.Id,
            ZoneName = request.ZoneName
        };

        await standingZoneRepo.AddAsync(standingZone);
        await standingZoneRepo.SaveChangesAsync();

        return new CreateStandingZoneResponse { Id = standingZone.Id };
    }
}
