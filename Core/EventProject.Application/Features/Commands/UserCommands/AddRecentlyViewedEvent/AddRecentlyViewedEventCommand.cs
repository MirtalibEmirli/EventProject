using EventProject.Application.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.UserCommands.AddRecentlyViewedEvent;

public class AddRecentlyViewedEventCommand:IRequest<BaseResponseModel>
{
    public required Guid EventId { get; set; }
    public required Guid UserId { get; set; }
}

