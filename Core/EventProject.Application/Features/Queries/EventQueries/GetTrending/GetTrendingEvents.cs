using AutoMapper;
using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Queries.EventQueries.GetTrending;

public class GetTrendingEventsCommand : IRequest<ResponseModel<List<GetTrendingEventsDto>>>
{
}
public class GetTrendingEvents(IEventReadRepository readRepository, IMapper mapper) : IRequestHandler<GetTrendingEventsCommand, ResponseModel<List<GetTrendingEventsDto>>>
{
    public async Task<ResponseModel<List<GetTrendingEventsDto>>> Handle(GetTrendingEventsCommand request, CancellationToken cancellationToken)
    {

        var trendingEvents = readRepository.GetAll() .Include(e => e.MediaFiles).Where(e => e.IsDeleted != null&&e.IsTrend == true);
    


        List<GetTrendingEventsDto> trendingDtos = new();
        foreach (var item in trendingEvents)
        {
            var obj = mapper.Map<GetTrendingEventsDto>(item);
            obj.MediaUrls =item.MediaFiles!=null ? item.MediaFiles.Select(m => m.FileName).ToList():new List<string>();
            trendingDtos.Add(obj);
        }

        return new ResponseModel<List<GetTrendingEventsDto>>{
            Data = trendingDtos,
            IsSuccess = true,
            Message="Trending events uploaded succesfully"
        };
    }
}
