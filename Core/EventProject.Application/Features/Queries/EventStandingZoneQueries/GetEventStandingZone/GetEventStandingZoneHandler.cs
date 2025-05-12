using EventProject.Application.Repositories.StandingZones;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetEventStandingZone;

public class GetEventStandingZoneHandler : IRequestHandler<GetEventStandingZoneRequest, ResponseModel<List<GetEventStandingZoneResponse>>>
{
    private readonly IStandingZoneReadRepository standingZoneReadRepository;
    private readonly IVenueReadRepository

        venueReadRepository;

    public GetEventStandingZoneHandler(IVenueReadRepository venueReadRepository)
    {
        this.venueReadRepository = venueReadRepository;
    }

    public async Task<ResponseModel<List<GetEventStandingZoneResponse>>> Handle(GetEventStandingZoneRequest request, CancellationToken cancellationToken)
    {
        var venues = await venueReadRepository.GetByIdAsync(request.VenueId.ToString());
        var venueStandingZones = venues.StandingZones.ToList();

        if (venueStandingZones == null || !venueStandingZones.Any())
        {
            return new ResponseModel<List<GetEventStandingZoneResponse>>
            {
                IsSuccess = false,
                Message = "No standing zones found for the specified venue."
            };
        }

        var standingZonesResult = venueStandingZones.Select(sz => new GetEventStandingZoneResponse
        {
            Id = sz.Id,
            Capacity = sz.Capacity,
            VenueId = sz.VenueId,
            ZoneName = sz.ZoneName.ToString(), 
        }).ToList();
        return new ResponseModel<List<GetEventStandingZoneResponse>>
        {
            IsSuccess = true,
            Message = "Standing zones retrieved successfully.",
            Data = standingZonesResult
        };  
        throw new NotImplementedException();
    }
}
