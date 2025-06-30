using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace EventProject.Application.Features.Queries.EventQueries.GetEvents;

public class GetEventsHandler : IRequestHandler<GetEventsRequest, ResponseModel<List<GetEventsResponse>>>
{
    private readonly IEventReadRepository eventReadRepository;
    private readonly ILogger<GetEventsHandler> logger;

    public GetEventsHandler(IEventReadRepository eventReadRepository,ILogger<GetEventsHandler> logger)
    {
        this.eventReadRepository = eventReadRepository;
        this.logger = logger;
    }

    public async Task<ResponseModel<List<GetEventsResponse>>> Handle(GetEventsRequest request, CancellationToken cancellationToken)
    {
        var query = eventReadRepository.GetAll()
                                       .Include(e => e.Location)
                                       .Include(e => e.Category)
                                       .Include(e => e.MediaFiles).Where(e => e.IsDeleted == false); //



        //filters-----
        if (request.StartDate.HasValue)
            query = query.Where(e => e.StartTime >= request.StartDate.Value);

        if (request.EndDate.HasValue)
            query = query.Where(e => e.EndTime <= request.EndDate.Value);

        if (request.VenueId.HasValue)
            query = query.Where(e => e.LocationId == request.VenueId.Value);

        if (request.CategoryId.HasValue)
            query = query.Where(e => e.CategoryId == request.CategoryId.Value);

        if (request.MinPrice.HasValue)
            query = query.Where(e => e.MinPrice >= request.MinPrice.Value);

        if (request.MaxPrice.HasValue)
            query = query.Where(e => e.MaxPrice <= request.MaxPrice.Value);




        var totalCount = await query.CountAsync(cancellationToken);

        var result = await query
            .Skip(request.Page * request.Size)
            .Take(request.Size)
            .Select(e => new GetEventsResponse
            {
                Id = e.Id,
                Title = e.Title,
                StartTime = e.StartTime,
                AgeLimit = e.AgeLimit,
                MinPrice = e.MinPrice,
                VenueName = e.Location.Name,
                CategoryId = e.CategoryId,
                Status = e.Status,
                MediaUrls = e.MediaFiles.Where(m => m.IsDeleted != true)
                 .Select(m => m.FileName)
                 .ToList(),
                MaxPrice = e.MaxPrice,
                EndTime = e.EndTime,
                Description = e.Description,


            }).ToListAsync(cancellationToken);
        if (totalCount<=0)
        {
            logger.LogError("Event hyoxudr");
            throw new BadRequestException("Event yoxdur");

        }

        return new ResponseModel<List<GetEventsResponse>>
        {
            IsSuccess = true,
            Data = result
        };
    }
}
