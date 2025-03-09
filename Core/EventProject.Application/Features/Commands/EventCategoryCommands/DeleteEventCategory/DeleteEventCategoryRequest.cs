using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.DeleteEventCategory;

public class DeleteEventCategoryRequest:IRequest<ResponseModel<DeleteEventCategoryResponse>>
{
    public string Id { get; set; }
}
