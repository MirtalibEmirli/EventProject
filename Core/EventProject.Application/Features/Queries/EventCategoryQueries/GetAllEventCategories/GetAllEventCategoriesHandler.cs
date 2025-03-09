using EventProject.Application.DTOs;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventCategoryQueries.GetAllEventCategories;

public class GetAllEventCategoriesHandler(IEventCategoryReadRepository eventCategoryReadRepository) :IRequestHandler<GetAllEventCategoriesRequest, ResponseModel<GetAllEventCategoriesResponse>>
{

	private readonly IEventCategoryReadRepository _eventCategoryReadRepository = eventCategoryReadRepository;
	   
	public async Task<ResponseModel<GetAllEventCategoriesResponse>> Handle(GetAllEventCategoriesRequest request, CancellationToken cancellationToken)
	{
		var categories = await  _eventCategoryReadRepository.GetAllAsync();
		if (categories is null) return  new ResponseModel<GetAllEventCategoriesResponse>
		{
			Data=null,
			Message="Categories is null",
			IsSuccess=false
		};

		var categoryList = categories.Select(c => new GetAllCategories
		{
			Name=c.CategoryName
		});

		return new ResponseModel<GetAllEventCategoriesResponse>()
		{ 
		   Data=new GetAllEventCategoriesResponse() {
			 NamesCategories=categoryList
		   },
		   Message="Get All Categories Successfully"
		};




	}


}
