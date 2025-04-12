using AutoMapper;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventQueries.GetTrending;

public class GetTrendingEventsCommand : IRequest<ResponseModel<List<GetTrendingEventsDto>>>
{

}
public class GetTrendingEvents(IEventReadRepository readRepository, IMapper mapper) : IRequestHandler<GetTrendingEventsCommand, ResponseModel<List<GetTrendingEventsDto>>>
{
    public async Task<ResponseModel<List<GetTrendingEventsDto>>> Handle(GetTrendingEventsCommand request, CancellationToken cancellationToken)
    {

        var trendingEvents = readRepository.GetWhere(x => x.IsTrend == true);
        List<GetTrendingEventsDto> trendingDtos = new();
        foreach (var item in trendingEvents)
        {
            var obj = mapper.Map<GetTrendingEventsDto>(item);
            trendingDtos.Add(obj);
        }
        return new ResponseModel<List<GetTrendingEventsDto>>{
            Data = trendingDtos,
            IsSuccess = true,
        };
        throw new NotImplementedException();
    }
}

public class GetTrendingEventsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PosterImg { get; set; }
    public int Address { get; set; }
    public int date { get; set; }
    public int MinPrice { get; set; }

}
