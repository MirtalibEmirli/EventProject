using EventProject.Application.DTOs;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
namespace EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;

public class GetAllVenueRequest: IRequest<ResponseModel<List<GetAllVenueResponse>>>
{

}
