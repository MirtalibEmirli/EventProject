using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.VenueEventMedia;
public record GetAllVenueEventMediaQuery() : IRequest<ResponseModel<List<string>>>
{
    public Guid VenueId { get; set; }
}


public class VenueEventMediaHandler(IEventReadRepository evenReadRepository) : IRequestHandler<GetAllVenueEventMediaQuery, ResponseModel<List<string>>>
{
    public async Task<ResponseModel<List<string>>> Handle(GetAllVenueEventMediaQuery request, CancellationToken cancellationToken)
    {

        var events = evenReadRepository.GetWhere(e => e.LocationId == request.VenueId && e.IsDeleted != true).ToList();


        var medias = events
           .SelectMany(e => e.MediaFiles.Select(m => m.FileName))
           .ToList();
        medias.ForEach(m => Console.WriteLine(m));
        return new ResponseModel<List<string>>
        {
            Data = medias
        };

    }
}
