using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone
{
    public class GetEventStandingZoneRequest:IRequest<GetEventStandingZoneResponse>
    {
        public Guid Id { get; set; }
    }
}
