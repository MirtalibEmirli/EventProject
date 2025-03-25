using EventProject.Application.Features.Commands.VenueCommands.DeleteVenue;
using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.VenueCommands.DeleteVenue;

public class DeleteVenueRequest:IRequest<ResponseModel<Unit>>
{
    public Guid Id { get; set; }
}
