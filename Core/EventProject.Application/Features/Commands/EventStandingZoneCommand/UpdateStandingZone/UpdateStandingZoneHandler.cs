using EventProject.Application.Repositories.StandingZones;
using EventProject.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.UpdateStandingZone
{
    internal class UpdateStandingZoneHandler : IRequestHandler<UpdateStandingZoneRequest, bool>
    {

        private readonly IStandingZoneReadRepository standingZoneReadRepo;
        private readonly IStandingZoneWriteRepository standingZoneWriteRepo;

        public async Task<bool> Handle(UpdateStandingZoneRequest request, CancellationToken cancellationToken)
        {
            var zone = await standingZoneReadRepo.GetByIdAsync(request.Id.ToString());

            if (zone == null) return false;

            zone.ZoneName = Enum.Parse<SZoneType>(request.ZoneName);
            zone.Capacity = request.Capacity;
            zone.VenueId = request.VenueId;

            await standingZoneWriteRepo.SaveChangesAsync();
            return true;
        }
    }
}
