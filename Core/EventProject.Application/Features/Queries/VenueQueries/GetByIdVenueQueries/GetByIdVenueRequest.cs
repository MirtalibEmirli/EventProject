using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.VenueQueries.GetByIdVenueQueries;

public class GetByIdVenueRequest:IRequest<ResponseModel<GetByIdVenueResponse>>
{
    public Guid Id { get; set; }
}
