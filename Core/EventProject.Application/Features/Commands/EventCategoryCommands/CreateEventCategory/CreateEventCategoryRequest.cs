using EventProject.Application.ResponseModels.Generics;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;

public class CreateEventCategoryRequest:IRequest<ResponseModel<CreateEventCategoryResponse>>
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Description { get; set; }
   
}
