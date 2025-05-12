using EventProject.Application.Exceptions;
using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.StandingZones;
using EventProject.Application.Repositories.Venues;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using MediatR;

public class CreateStandingZoneHandler : IRequestHandler<CreateStandingZoneRequest, CreateStandingZoneResponse>
{
    private readonly IStandingZoneWriteRepository standingZoneRepo;
    private readonly IStandingZoneReadRepository _standingReadZoneRepo;
    public CreateStandingZoneHandler(IStandingZoneWriteRepository standingZoneRepo,IStandingZoneReadRepository 
        standing)
    {
        this.standingZoneRepo = standingZoneRepo;
        _standingReadZoneRepo=standing;
    }
    public async Task<CreateStandingZoneResponse> Handle(CreateStandingZoneRequest request, CancellationToken cancellationToken)
    {
        

        if (!Enum.TryParse<SZoneType>(request.ZoneName, true, out var zoneEnum))
            throw new BadRequestException("Daxil edilən zona adı düzgün deyil.");


        var existingZone =   _standingReadZoneRepo.GetWhere(z => z.EventId == request.EventId && z.ZoneName == zoneEnum).FirstOrDefault();

        if (existingZone!=null)
        {
            existingZone.Price = request.Price;
            existingZone.Capacity = request.Capacity;
            existingZone.VenueId = request.VenueId;
            standingZoneRepo.Update(existingZone);
            await standingZoneRepo.SaveChangesAsync();
           return new CreateStandingZoneResponse { Id = existingZone.Id };  
        }
        else
        {
            var standingZone = new StandingZone
            {
                Capacity = request.Capacity,
                VenueId = request.VenueId,
                ZoneName = zoneEnum,
                EventId = request.EventId,
                Price = request.Price,
            };

            await standingZoneRepo.AddAsync(standingZone);
            await standingZoneRepo.SaveChangesAsync();
            return new CreateStandingZoneResponse { Id = standingZone.Id };
        }


        
    }
}
