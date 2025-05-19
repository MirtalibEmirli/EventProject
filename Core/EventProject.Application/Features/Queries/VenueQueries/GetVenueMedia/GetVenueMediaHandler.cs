using EventProject.Application.Repositories.VenueMediaFiles;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.GetVenueMedia;


public record GetVenueMediasQuery(Guid Id) : IRequest<ResponseModel<List<string>>>;


public  class GetVenueMediasHandler(IVenueMediaFileReadRepository venueMediaFileRead) : IRequestHandler<GetVenueMediasQuery, ResponseModel<List<string>>>
{
    public async Task<ResponseModel<List<string>>> Handle(GetVenueMediasQuery request, CancellationToken cancellationToken)
    {

        var medias = venueMediaFileRead.GetWhere(x => x.VenueId == request.Id && x.IsDeleted != true).Select(x => x.FileName).ToList(); 

        return new ResponseModel<List<string>>
        {
            Data   =medias,
            IsSuccess=true,
            Message="VenueMedias"
        }; 
        throw new NotImplementedException();
    }
}
 