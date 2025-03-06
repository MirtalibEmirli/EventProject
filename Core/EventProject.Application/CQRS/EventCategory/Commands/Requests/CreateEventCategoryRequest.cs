using EventProject.Application.CQRS.EventCategory.Commands.Responses;
using MediatR;

namespace EventProject.Application.CQRS.EventCategory.Commands.Requests
{
    public class CreateEventCategoryRequest:IRequest<CreateEventCategoryResponse>
    {
        public string CategoryName { get; set; }   

        public string? Description { get; set; }
    }
}
