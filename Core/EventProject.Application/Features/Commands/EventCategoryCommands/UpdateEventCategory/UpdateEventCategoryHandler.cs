
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.UpdateEventCategory;

public class UpdateEventCategoryHandler(IEventCategoryWriteRepository eventCategoryWriteRepository, IEventCategoryReadRepository eventCategoryReadRepository) : IRequestHandler<UpdateEventCategoryRequest,ResponseModel<UpdateEventCategoryResponse>>
{

	private readonly IEventCategoryWriteRepository _eventCategoryWriteRepository = eventCategoryWriteRepository;
	private readonly IEventCategoryReadRepository _eventCategoryReadRepository = eventCategoryReadRepository;

	public async Task<ResponseModel<UpdateEventCategoryResponse>> Handle(UpdateEventCategoryRequest request, CancellationToken cancellationToken)
	{
		if (request == null) throw new BadRequestException("Request is null");




		var entity= await _eventCategoryReadRepository.GetByIdAsync(request.Id);
		if (entity is null)
		{
			return new ResponseModel<UpdateEventCategoryResponse>()
			{
				Data=null,
				Message="Entity is null",
				IsSuccess=false
			};
		}
	     
		entity.CategoryName=request.CategoryName;
		entity.Description=request.Description;

		 _eventCategoryWriteRepository.Update(entity);
		await _eventCategoryWriteRepository.SaveChangesAsync();

		return new ResponseModel<UpdateEventCategoryResponse>() { Data=null,Message="Successfuly Update" };



    }
}
