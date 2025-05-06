using EventProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventQueries.GetEvents;

public class GetEventsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
 
    public string FormattedDate => StartTime.ToString("dd MMMM yyyy");

    public int AgeLimit { get; set; }
    public float MinPrice { get; set; }
    public EventStatus Status { get; set; }
    public Guid CategoryId { get; set; }
    public string VenueName { get; set; } = string.Empty;
   

    public List<string> MediaUrls { get; set; } = new();

}
