using AutoMapper;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.GetAllVenueQueries;

public class GetAllVenueHandler : IRequestHandler<GetAllVenueRequest, ResponseModel<List<GetAllVenueResponse>>>
{
    private readonly IVenueReadRepository _venueReadRepository;
    private readonly IMapper _mapper;
    public GetAllVenueHandler(IVenueReadRepository venueReadRepository, IMapper mapper)
    {
        _venueReadRepository = venueReadRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<List<GetAllVenueResponse>>> Handle(GetAllVenueRequest request, CancellationToken cancellationToken)
    {
        var venues =  _venueReadRepository.GetAll();
        var result = _mapper.Map<List<GetAllVenueResponse>>(venues);

        return new ResponseModel<List<GetAllVenueResponse>>
        {
            IsSuccess = true,
            Data = result
        };
    }
}
