using EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;
using EventProject.Application.Features.Commands.VenueCommands.DeleteVenue;
using EventProject.Application.Repositories.Venues;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.VenueCommands.DeleteVenue
{
    public class DeleteVenueHandler : IRequestHandler<DeleteVenueRequest, ResponseModel<Unit>>
    {
        private readonly IVenueWriteRepository _venueWriteRepository;

        public DeleteVenueHandler(IVenueWriteRepository venueWriteRepository)
        {
            _venueWriteRepository = venueWriteRepository;
        }

        public async Task<ResponseModel<Unit>> Handle(DeleteVenueRequest request, CancellationToken cancellationToken)
        {
            await _venueWriteRepository.SoftDeleteAsync(request.Id.ToString());
            await _venueWriteRepository.SaveChangesAsync();

           
            return new ResponseModel<Unit>
            {

                Data = Unit.Value,
                IsSuccess = true,
                Message = "Deleted Successfully"

            };
        }
    }
}
