using AutoMapper;
using EventProject.Application.Exceptions;
using EventProject.Application.Repositories.EventCategories;
using EventProject.Application.Repositories.Events;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCommands.UpdateEvent;

public class UpdateEventHanlder(IEventReadRepository readRepository,IEventCategoryReadRepository eventCategoryRead, IMapper mapper, IEventWriteRepository writeRepository) : IRequestHandler<UpdateEventRequest, ResponseModel<Unit>>
{
    public async Task<ResponseModel<Unit>> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
    {
        var currentEvent = await readRepository.GetByIdAsync(request.EventId.ToString());
        if (currentEvent == null&&currentEvent?.IsDeleted==false)
            throw new NotFoundException($"There is no event with {request.EventId}");

        mapper.Map(request, currentEvent);
        writeRepository.Update(currentEvent);
         
 


        if (request.CategoryId != null && request.CategoryId != Guid.Empty)
        {
            var newCategory = await eventCategoryRead.GetByIdAsync(request.CategoryId.Value.ToString());
            currentEvent.Category = newCategory;
        }

        await writeRepository.SaveChangesAsync();

        return new ResponseModel<Unit>
         { 
            IsSuccess = true,
            Message = "Data Updated"
        };
    }
}
