using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventQueries.GetEvents;

   public  class GetEventsRequest:IRequest<ResponseModel<List<GetEventsResponse>>>
   {

       public DateTime? StartDate { get; set; }
       public DateTime? EndDate { get; set; }
      
       public Guid? VenueId { get; set; }
       public Guid? CategoryId { get; set; }
      
       public float? MinPrice { get; set; }
       public float? MaxPrice { get; set; }
    
       public int Page { get; set; } = 0;
       public int Size { get; set; } = 6;

   }
