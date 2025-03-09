using EventProject.Application.ResponseModels.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventCategoryQueries.GetEventCategoryById;

public class GetEventCategoryByIdRequest:IRequest<ResponseModel<GetEventCategoryByIdResponse>>
{
    public string Id { get; set; }
}
