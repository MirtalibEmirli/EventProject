using EventProject.Application.Repositories.Events;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.Search;
public record SearchRequest(string SearchText) : IRequest<ResponseModel<List<SearchResponse>>>;

public record SearchResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
}

public class SearchHandler(IEventReadRepository eventReadRepository, IVenueReadRepository venueReadRepository) : IRequestHandler<SearchRequest, ResponseModel<List<SearchResponse>>>
{
    public async Task<ResponseModel<List<SearchResponse>>> Handle(SearchRequest request, CancellationToken cancellationToken)
    {
        var eventsDto = eventReadRepository.GetWhere(e => e.Title.Contains(request.SearchText)).Select(e =>
            new SearchResponse
            {
                Id = e.Id,
                Name = e.Title,
                Type = "event"
            }
        ).ToList();

        var venuesDto = venueReadRepository.GetWhere(v => v.Name.Contains(request.SearchText)).Select(v => new SearchResponse { Name = v.Name, Id = v.Id, Type = "venue" }).ToList();

        var result = eventsDto.Concat(venuesDto).ToList();
        return new ResponseModel<List<SearchResponse>>
        {
            Data = result,
            Message = "Search results",
            IsSuccess = true
        };

    }
}
