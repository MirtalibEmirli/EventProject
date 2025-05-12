using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone;

public class GetEventStandingZoneRequest:IRequest<ResponseModel<List<GetEventStandingZoneResponse>>>
{
    public Guid VenueId { get; set; }
}
