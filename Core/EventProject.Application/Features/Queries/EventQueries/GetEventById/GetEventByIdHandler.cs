using EventProject.Application.DTOs;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventQueries.GetEventById;

public class GetEventByIdHandler : IRequestHandler<GetEventByIdRequest, ResponseModel<GetEventByIdResponse>>
{

    private readonly IEventReadRepository _eventReadRepository;

    public GetEventByIdHandler(IEventReadRepository eventReadRepository)
    {
        _eventReadRepository = eventReadRepository;
    }

    public async Task<ResponseModel<GetEventByIdResponse>> Handle(GetEventByIdRequest request, CancellationToken cancellationToken)
    {

        var eventEntity = await _eventReadRepository.GetAll()
                                                    .Include(e => e.Category)
                                                    .Include(e => e.Location)
                                                    .Include(e => e.Location.Seats)
                                                    .Include(e => e.MediaFiles)
                                                    .Include(e => e.EventSeatPrices)
                                                    .Include(e =>e.Location.StandingZones)
                                                    .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (eventEntity is null)
            return new ResponseModel<GetEventByIdResponse>(new List<string> { "Event tapılmadı." });



        var response = new GetEventByIdResponse
        {
            Id = eventEntity.Id,
            Title = eventEntity.Title,
            Description = eventEntity.Description,
            StartTime = eventEntity.StartTime,
            EndTime = eventEntity.EndTime,
            AgeLimit = eventEntity.AgeLimit,
            MinPrice = eventEntity.MinPrice,
            MaxPrice = eventEntity.MaxPrice,
            VenueName = eventEntity.Location.Name,
            VenueAddress = eventEntity.Location.Address,
            VenueId=eventEntity.LocationId,
            CategoryId = eventEntity.CategoryId,
            CategoryName = eventEntity.Category.CategoryName,
            MediaUrls = eventEntity.MediaFiles.Select(m => m.FileName).ToList(),
            Seats = eventEntity.Location.Seats.Select(seat =>
            {
                var price = eventEntity.EventSeatPrices.FirstOrDefault(p => p.SeatId == seat.Id)?.Price;

                return new SeatDTO
                {
                    Id = seat.Id,
                    Section = seat.Section,
                    Row = seat.Row,
                    Number = seat.Number,
                    
                };
            }).ToList()
        };

        return new ResponseModel<GetEventByIdResponse>
        {
            IsSuccess = true,
            Data = response
        };

    }
}
