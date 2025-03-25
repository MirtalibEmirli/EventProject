using AutoMapper;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;

public class GetByIdVenueHandler : IRequestHandler<GetByIdVenueRequest, ResponseModel<GetByIdVenueResponse>>
{
    private readonly IVenueReadRepository _venueReadRepository;
    private readonly IMapper  _mapper;
    public GetByIdVenueHandler(IVenueReadRepository venueReadRepository, IMapper mapper)
    {
        _venueReadRepository = venueReadRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<GetByIdVenueResponse>> Handle(GetByIdVenueRequest request, CancellationToken cancellationToken)
    {
        var venue = await _venueReadRepository.GetByIdAsync(request.Id.ToString());
        if (venue is null)   return new ResponseModel<GetByIdVenueResponse>(new List<string> { "Venue tapılmadı." });

        var response = _mapper.Map<GetByIdVenueResponse>(venue);

        return new ResponseModel<GetByIdVenueResponse>
        {
            IsSuccess = true,
            Data = response
        };
    }
}
