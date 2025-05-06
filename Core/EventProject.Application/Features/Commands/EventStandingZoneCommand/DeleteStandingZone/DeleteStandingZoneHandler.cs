using EventProject.Application.Repositories.StandingZones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone
{
    public class DeleteStandingZoneHandler : IRequestHandler<DeleteStandingZoneRequest, bool>
    {
        private readonly IStandingZoneWriteRepository standingZoneWriteRepository;

        private readonly IStandingZoneReadRepository standingZoneReadRepository;

        public async Task<bool> Handle(DeleteStandingZoneRequest request, CancellationToken cancellationToken)
        {
            var zone = await standingZoneReadRepository.GetByIdAsync(request.Id.ToString());
            if(zone == null) return false;

            await standingZoneWriteRepository.SoftDeleteAsync(request.Id.ToString());
            await standingZoneWriteRepository.SaveChangesAsync();
            return true;


        }
    }
}
