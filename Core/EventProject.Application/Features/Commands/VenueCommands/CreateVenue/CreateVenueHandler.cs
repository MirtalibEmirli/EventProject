using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.VenueCommands.CreateVenue;

public class CreateVenueHandler : IRequestHandler<CreateVenueRequest, ResponseModel<Unit>>
{
    public Task<ResponseModel<Unit>> Handle(CreateVenueRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
