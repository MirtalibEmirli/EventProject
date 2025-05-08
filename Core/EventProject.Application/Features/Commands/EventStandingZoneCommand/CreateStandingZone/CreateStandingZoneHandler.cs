using EventProject.Application.Repositories.StandingZones;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;

public class CreateStandingZoneHandler : IRequestHandler<CreateStandingZoneRequest, CreateStandingZoneResponse>
{
    private readonly IStandingZoneWriteRepository standingZoneRepo;

    public async Task<CreateStandingZoneResponse> Handle(CreateStandingZoneRequest request, CancellationToken cancellationToken)
    {
        var zone = Enum.Parse<SZoneType>(request.ZoneName);


        var standingZone = new StandingZone() { Capacity = request.Capacity, VenueId=Guid.Parse(request.VenueId), ZoneName= zone };

       await  standingZoneRepo.AddAsync(standingZone);
       await standingZoneRepo.SaveChangesAsync();


        return new CreateStandingZoneResponse() { Id=standingZone.Id };
    }
}
