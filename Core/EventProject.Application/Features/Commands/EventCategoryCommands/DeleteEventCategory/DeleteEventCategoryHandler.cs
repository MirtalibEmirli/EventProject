using EventProject.Application.Repositories.EventCategories;
using EventProject.Domain.Entities;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;

public class DeleteEventCategoryHandler(IEventCategoryWriteRepository categoryWriteRepository) : IRequestHandler<DeleteEventCategoryRequest, DeleteEventCategoryResponse>
{
	private readonly IEventCategoryWriteRepository _categoryWriteRepository  = categoryWriteRepository;

	public async Task<DeleteEventCategoryResponse> Handle(DeleteEventCategoryRequest request,CancellationToken cancellationToken)
	{
		await _categoryWriteRepository.DeleteAsync(id: request.Id);
		await _categoryWriteRepository.SaveChangesAsync();
		return new DeleteEventCategoryResponse();

	}
}
