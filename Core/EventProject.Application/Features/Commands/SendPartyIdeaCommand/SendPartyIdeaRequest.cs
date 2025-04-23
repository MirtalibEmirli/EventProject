using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Commands.SendPartyIdeaCommand;

public class SendPartyIdeaRequest:IRequest<bool>
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int EstimatedNumberOfGuests { get; set; }
    public DateTime Date { get; set; }
    public string Venue { get; set; } = null!;
    public string Description { get; set; } = null!;
}
