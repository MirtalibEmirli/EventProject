using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using FluentValidation;

namespace EventProject.Application.Features.Commands.EventCategoryCommands
{
    public class CreateCategoryValidator:AbstractValidator<CreateEventCategoryRequest>
    {
        //bunu duzgun foldere qaldrmaq lazimdir
        public CreateCategoryValidator()
        {
                RuleFor(x=>x.CategoryName).NotEmpty().MinimumLength(4);
        }
    }
}
