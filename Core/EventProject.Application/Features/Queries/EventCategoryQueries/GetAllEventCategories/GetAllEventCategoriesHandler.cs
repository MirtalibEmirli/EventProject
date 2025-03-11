using AutoMapper;
using EventProject.Application.DTOs;
using EventProject.Application.Exceptions;
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

public class GetAllEventCategoriesHandler(IEventCategoryReadRepository eventCategoryReadRepository,IMapper mapper) :IRequestHandler<GetAllEventCategoriesRequest, ResponseModelPagination<GetAllCategories>>
{

	private readonly IEventCategoryReadRepository _eventCategoryReadRepository = eventCategoryReadRepository;
	   private readonly IMapper _mapper=mapper;
	public async Task<ResponseModelPagination<GetAllCategories>> Handle(GetAllEventCategoriesRequest request, CancellationToken cancellationToken)
	{
		var categories = await  _eventCategoryReadRepository.GetAllAsync();
		if (categories is null) throw new BadRequestException("Request is null ,Try again");
		var totalCount = categories.Count();
		categories = categories.Skip((request.Page - 1) * (request.Limit)).ToList();

		var itemsToMap = new List<GetAllCategories>();//bunu dto   eddim response qalsn

		foreach (var item in categories)
		{
			var data = _mapper.Map<GetAllCategories>(item);			

			itemsToMap.Add(data);
        }

		var responseModel = new Pagination<GetAllCategories>() { Items=itemsToMap,TotalCount= totalCount };

		return   new ResponseModelPagination<GetAllCategories>()
		{
			Data = responseModel,
			IsSuccess = true,
			Message="GetAllCategories"
		};

		//var categoryList = categories.Select(c => new GetAllCategories
		//{
		//	Name=c.CategoryName
		//});

		 




	}


}
