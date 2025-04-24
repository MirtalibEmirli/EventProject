using EventProject.Application.Features.Commands.SendPartyIdeaCommand.Contact;
using FluentValidation;

namespace EventProject.Application.Validations;

public class Contact : AbstractValidator<ContactUsCommand>
{
    public Contact()
    {
        RuleFor(x => x.email).NotEmpty().EmailAddress();
        RuleFor(x => x.firstName).NotEmpty().MinimumLength(3).Matches(@"^[A-Za-zƏəÖöÜüÇçŞşĞğIıİi]+$")
    .WithMessage("Ad yalnız hərflərdən ibarət olmalıdır."); ;
        RuleFor((x => x.lastName)).NotEmpty().MinimumLength(4).Matches(@"^[A-Za-zƏəÖöÜüÇçŞşĞğIıİi]+$")
    .WithMessage("Ad yalnız hərflərdən ibarət olmalıdır.");

        RuleFor(x => x.phone).NotEmpty().WithMessage("Telefon nömrəsi boş olmaz").Matches("^\\+?[1-9][0-9]{7,12}$").WithMessage("Telefon nömrəsi +994 ilə başlamalıdır");
    }
}
