using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Features.Commands.VenueCommands.UpdateVenue;

public class UpdateVenueHandler : IRequestHandler<UpdateVenueRequest, ResponseModel<Unit>>
{

    private readonly IVenueReadRepository _venueReadRepository;
    private readonly IVenueWriteRepository _venueWriteRepository;

    public UpdateVenueHandler(IVenueReadRepository venueReadRepository, IVenueWriteRepository venueWriteRepository)
    {
        _venueReadRepository = venueReadRepository;
        _venueWriteRepository = venueWriteRepository;
    }

    public async Task<ResponseModel<Unit>> Handle(UpdateVenueRequest request, CancellationToken cancellationToken)
    {
        var venue = await _venueReadRepository.GetByIdAsync(request.Id.ToString());
        if (venue is  null)
            return new ResponseModel<Unit>(new List<string> { "Venue tapılmadı." });

        venue.Name = request.Name;
        venue.Address = request.Address;
        venue.Description = request.Description;
        venue.Phone = request.Phone;
        venue.Latitude = request.Latitude;
        venue.Longitude = request.Longitude;

        await _venueWriteRepository.SaveChangesAsync();

        return new ResponseModel<Unit>
        {
            IsSuccess = true,
            Data = Unit.Value
        };
    }
}
