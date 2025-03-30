using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventQueries.GetEventById;

public class GetEventByIdRequest:IRequest<ResponseModel<GetEventByIdResponse>>
{
    public Guid Id { get; set; }
}
