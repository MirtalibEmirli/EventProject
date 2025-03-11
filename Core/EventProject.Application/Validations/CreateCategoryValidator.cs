using EventProject.Application.Features.Commands.EventCategoryCommands.CreateEventCategory;
using FluentValidation;

namespace EventProject.Application.Validations
{
    public class CreateCategoryValidator : AbstractValidator<CreateEventCategoryRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().MinimumLength(4);
        }
    }
}
