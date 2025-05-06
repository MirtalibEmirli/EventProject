using EventProject.Application.Repositories.StandingZones;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone
{
    public class GetEventStandingZoneHandler : IRequestHandler<GetEventStandingZoneRequest, GetEventStandingZoneResponse>
    {
        private readonly IStandingZoneReadRepository standingZoneReadRepository;
        public async Task<GetEventStandingZoneResponse> Handle(GetEventStandingZoneRequest request, CancellationToken cancellationToken)
        {
            var zone = await standingZoneReadRepository.GetByIdAsync(request.Id.ToString());

            if (zone == null) throw new Exception("Not Found StandingZone");

            return new GetEventStandingZoneResponse()
            {
                Id = zone.Id,
                Capacity = zone.Capacity,
                VenueId = zone.VenueId,
                ZoneName = zone.ZoneName.ToString()
            };



        }
    }
}
