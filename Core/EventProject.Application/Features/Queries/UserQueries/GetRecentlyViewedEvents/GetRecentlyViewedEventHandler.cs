using AutoMapper;
using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventProject.Application.Features.Queries.UserQueries.GetRecentlyViewedEvents;

public class GetRecentlyViewedEventHandler(IUserRwEventsReadRepository userRwEventsRead, IHttpContextAccessor contextAccessor, IMapper mapper) : IRequestHandler<GetRecentlyViewedEventQuery, ResponseModel<List<RVEventsDto>>>
{
    public async Task<ResponseModel<List<RVEventsDto>>> Handle(GetRecentlyViewedEventQuery request, CancellationToken cancellationToken)
    {
        var userIdClaim = contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) throw new UnauthorizedAccessException("User is not authenticated");

        var userId = Guid.Parse(userIdClaim.Value);

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
