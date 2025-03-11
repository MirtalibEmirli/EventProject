using EventProject.Application.DTOs;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.EventCategoryQueries.GetAllEventCategories;

public class GetAllEventCategoriesRequest:IRequest<ResponseModelPagination<GetAllCategories>>
{

    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 5;
}
