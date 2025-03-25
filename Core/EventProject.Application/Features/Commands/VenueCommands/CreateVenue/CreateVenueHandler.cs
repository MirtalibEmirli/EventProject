using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.VenueCommands.CreateVenue;

public class CreateVenueHandler : IRequestHandler<CreateVenueRequest, ResponseModel<Guid>>
{

    private readonly IVenueWriteRepository venueWriteRepository;

    public CreateVenueHandler(IVenueWriteRepository venueWriteRepository)
    {
        this.venueWriteRepository = venueWriteRepository;
    }

    public async Task<ResponseModel<Guid>> Handle(CreateVenueRequest request, CancellationToken cancellationToken)
    {
        var venue = new Venue
        {
            Name = request.Name,
            Address = request.Address,
            Description = request.Description,
            Phone = request.Phone,
            Latitude = request.Latitude,
            Longitude = request.Longitude
            
        };

         await  venueWriteRepository.AddAsync(venue);
        await venueWriteRepository.SaveChangesAsync();
        return new ResponseModel<Guid>
        {
            IsSuccess = true,
            Data = venue.Id
        };

    }
}
