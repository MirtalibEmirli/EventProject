using EventProject.Application.DTOs;
using EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;
using EventProject.Application.Repositories.Seats;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventProject.Application.Features.Queries.EventSeatQueries;

public class GetSeatsByVenueHandler : IRequestHandler<GetSeatsByVenueQuery,ResponseModel<GetSeatsByVenueResponse>>
{

    private readonly IVenueReadRepository _venueReadRepository;
    private readonly ISeatReadRepository _seatReadRepository;

    public GetSeatsByVenueHandler(IVenueReadRepository venueReadRepository, ISeatReadRepository seatReadRepository)
    {
        _venueReadRepository = venueReadRepository;
        _seatReadRepository = seatReadRepository;
    }

    public  async Task<ResponseModel<GetSeatsByVenueResponse>> Handle(GetSeatsByVenueQuery request, CancellationToken cancellationToken)
    {
        var seats =await  _seatReadRepository.GetAll()
            .Where(s => s.VenueId == request.VenueId)
            .Select(s => new SeatDTO
            {
                Id = s.Id,
                Section = s.Section,
                Row = s.Row,
                Number = s.Number,
                Capacity = s.Capacity,
                X = s.X,
                Y = s.Y,
                Z = s.Z,
                RotationY = s.RotationY
            }).ToListAsync(cancellationToken);

       var result= new GetSeatsByVenueResponse() { Seats = seats };

        return new ResponseModel<GetSeatsByVenueResponse>
        {
            IsSuccess = true,
            Data = result
        };

    }
}

