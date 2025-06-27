//using EventProject.Application.Repositories.StandingZones;
//using EventProject.Application.ResponseModels.Generics;
//using MediatR;

//namespace EventProject.Application.Features.Queries.EventStandingZoneQueries.GetStandingZonesAdmin;

//public record GetStandingZonesByEventQuery() : IRequest<ResponseModel<List<GetStandingZonesByEventResponse>>>
//{
//    public Guid EventId { get; set; }
//}

//public class GetStandingZonesHandler : IRequestHandler<GetStandingZonesByEventQuery, ResponseModel<List<GetStandingZonesByEventResponse>>>
//{

//    private readonly IStandingZoneReadRepository _standingZoneReadRepository;

//    public GetStandingZonesHandler(IStandingZoneReadRepository standingZoneReadRepository)
//    {
//        _standingZoneReadRepository = standingZoneReadRepository;
//    }

//    public async Task<ResponseModel<List<GetStandingZonesByEventResponse>>> Handle(GetStandingZonesByEventQuery request, CancellationToken cancellationToken)
//    {

//        Console.WriteLine(request.EventId);
//        var zones = _standingZoneReadRepository.GetWhere(x => x.EventId == request.EventId && x.IsDeleted != true)?.Select(sz => new GetStandingZonesByEventResponse
//        {
//            Id = sz.Id,
//            ZoneName = sz.ZoneName.ToString(),
//            Capacity = sz.Capacity,
//            Price = sz.Price,
            
//        }).ToList();

//        if (zones == null || !zones.Any())
//        {
//            return  new ResponseModel<List<GetStandingZonesByEventResponse>>
//            {
//                IsSuccess = false,
//                Message = "No standing zones found for the specified event."
//            };
//        }
//        return new ResponseModel<List<GetStandingZonesByEventResponse>>()
//        {
//            Data = zones,   
//            IsSuccess=true,
//            Message= "Zonelar ugurla alindi"
//        };
//    }
//}

//public record GetStandingZonesByEventResponse
//{
//    public Guid Id { get; set; }
//    public string ZoneName { get; set; }
//    public int Capacity { get; set; }
//    public int Price { get; set; }
//}