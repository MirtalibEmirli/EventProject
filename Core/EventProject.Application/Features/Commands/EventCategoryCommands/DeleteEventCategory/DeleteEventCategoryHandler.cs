using AutoMapper;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.ResponseModels.Generics;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;

public class DeleteEventCategoryHandler(IEventCategoryWriteRepository categoryWriteRepository) : IRequestHandler<DeleteEventCategoryRequest, ResponseModel<DeleteEventCategoryResponse>>
{
	private readonly IEventCategoryWriteRepository _categoryWriteRepository  = categoryWriteRepository;


	public async Task<ResponseModel<DeleteEventCategoryResponse>> Handle(DeleteEventCategoryRequest request,CancellationToken cancellationToken)
	{


		await _categoryWriteRepository.SoftDeleteAsync(id: request.Id);
		await _categoryWriteRepository.SaveChangesAsync();

		var response = new DeleteEventCategoryResponse()
		{
			Id=request.Id
		};
		return new ResponseModel<DeleteEventCategoryResponse> {

			Data = response,
			IsSuccess=true,
			Message="Deleted Successfully"
			
		};

	}
}
