using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
// 
public class CreateEventCategoryRequest:IRequest<ResponseModel<CreateEventCategoryResponse>>
{
    public string Name { get; set; }
}
