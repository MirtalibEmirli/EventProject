using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.UserQueries.GetRecentlyViewedEvents;

public class GetRecentlyViewedEventQuery:IRequest<ResponseModel<List<RVEventsDto>>>
{

} 

public class RVEventsDto
{
    public List<string> MediaUrls { get; set; }
    public Guid Id { get; set; }
    public int MinPrice { get; set; }
    public DateTime StartTime { get; set; }

}
