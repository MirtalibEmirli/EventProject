using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventSeatPriceCommand;

public class CreateEventSeatPriceRequest:IRequest<ResponseModel<Unit>>
{
    public Guid EventId { get; set; }

}
