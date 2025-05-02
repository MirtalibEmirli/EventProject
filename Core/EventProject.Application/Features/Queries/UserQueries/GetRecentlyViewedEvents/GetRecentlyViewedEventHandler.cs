using AutoMapper;
using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventProject.Application.Features.Queries.UserQueries.GetRecentlyViewedEvents;

public class GetRecentlyViewedEventHandler(IUserRwEventsReadRepository userRwEventsRead, ICurrentUserService currentUserService, IMapper mapper) : IRequestHandler<GetRecentlyViewedEventQuery, ResponseModel<List<RVEventsDto>>>
{

    private readonly ICurrentUserService _currentUserService = currentUserService;
    public async Task<ResponseModel<List<RVEventsDto>>> Handle(GetRecentlyViewedEventQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();
        var events = await userRwEventsRead
       .GetWhereQuery(uv => uv.UserId == userId)
       .Include(uv => uv.Event)
           .ThenInclude(e => e.MediaFiles)
       .ToListAsync(cancellationToken);

        var rwEvents = events
            .Where(uv => uv.Event != null && uv.Event.IsDeleted == false)
            .Select(uv =>
            {
                var dto = mapper.Map<RVEventsDto>(uv.Event);
                dto.MediaUrls = uv.Event.MediaFiles.Select(e => e.FileName).ToList();
                return dto;
            }).ToList();

        return new ResponseModel<List<RVEventsDto>> { Data = rwEvents, IsSuccess = true, Message = "recentlyViewed Events " };

    }
}
