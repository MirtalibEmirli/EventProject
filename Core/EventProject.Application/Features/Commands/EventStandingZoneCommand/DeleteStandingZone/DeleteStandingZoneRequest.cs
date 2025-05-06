using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.EventStandingZoneCommand.DeleteStandingZone
{
    public class DeleteStandingZoneRequest:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
