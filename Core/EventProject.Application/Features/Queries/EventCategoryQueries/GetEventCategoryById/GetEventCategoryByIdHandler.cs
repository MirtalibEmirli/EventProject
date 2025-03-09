
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Queries.EventCategoryQueries.GetEventCategoryById;

public class GetEventCategoryByIdHandler(IEventCategoryReadRepository eventCategoryReadRepository) : IRequestHandler<GetEventCategoryByIdRequest, ResponseModel<GetEventCategoryByIdResponse>>
{
	private readonly IEventCategoryReadRepository _eventCategoryReadRepository = eventCategoryReadRepository;

	public async Task<ResponseModel<GetEventCategoryByIdResponse>> Handle(GetEventCategoryByIdRequest request, CancellationToken cancellationToken)
	{
		var category = await _eventCategoryReadRepository.GetByIdAsync(request.Id);
		if (category is null)
			return new ResponseModel<GetEventCategoryByIdResponse>()
			{
				Data=null,
				Message="Category is null",
				IsSuccess=false
			};

		return new ResponseModel<GetEventCategoryByIdResponse>()
		{
			Data=new GetEventCategoryByIdResponse()
			{
				Name=category.CategoryName,
			}

		};


	}
}









