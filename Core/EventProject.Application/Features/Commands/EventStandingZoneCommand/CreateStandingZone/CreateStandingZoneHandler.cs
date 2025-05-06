using EventProject.Application.Repositories.StandingZones;
using EventProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;

public class CreateStandingZoneHandler : IRequestHandler<CreateStandingZoneRequest, CreateStandingZoneResponse>
{
    private readonly IStandingZoneWriteRepository standingZoneRepo;

    public async Task<CreateStandingZoneResponse> Handle(CreateStandingZoneRequest request, CancellationToken cancellationToken)
    {
        
        var standingZone = new StandingZone() { Capacity = request.Capacity, VenueId=request.VenueId, ZoneName=request.ZoneName };

       await  standingZoneRepo.AddAsync(standingZone);
       await standingZoneRepo.SaveChangesAsync();


        return new CreateStandingZoneResponse() { Id=standingZone.Id };
    }
}
