using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.VenueQueries.Getvenuesforselectbox;
public record class GetvenuesforselectboxQuery : IRequest<ResponseModel<List<VenueSelectBoxDto>>>
{
}


public   class GetvenuesforselectboxHandler(IVenueReadRepository venueReadRepository) : IRequestHandler<GetvenuesforselectboxQuery,ResponseModel<List<VenueSelectBoxDto>>>
{
    public async Task<ResponseModel<List<VenueSelectBoxDto>>> Handle(GetvenuesforselectboxQuery request, CancellationToken cancellationToken)
    {
        var venues = venueReadRepository.GetAll().Select(v=>new VenueSelectBoxDto { VenueId=v.Id,VenueName=v.Name}).ToList();

       return new ResponseModel<List<VenueSelectBoxDto>>
       {
           Data = venues,
           Message = "Venues retrieved successfully",
           IsSuccess = true
       };       
    }
}

public class VenueSelectBoxDto
{
    public Guid VenueId { get; set; }
    public string VenueName { get; set; }

}