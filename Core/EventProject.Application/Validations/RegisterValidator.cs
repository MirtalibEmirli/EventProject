using EventProject.Application.Features.Commands.UserCommands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Gmail addresi daxil edin");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad   boş olmamalidir").MinimumLength(3).WithMessage("Ad minimum 3 simvol olmalidir").Must(name => char.IsUpper(name[0])).WithMessage("Ad böyük hərflə başlamalıdır!"); 

            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Soyad   boş olmamalidir").MinimumLength(3).WithMessage("Soyad minimum 4 simvol olmalidir").Must(x => char.IsUpper(x[0])).WithMessage("Soyad böyük hərflə başlamalıdır!");


            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password minimum 8 simvol olmaldir!").
                Must(password => password.Any(char.IsDigit) && password.Any(char.IsUpper)).WithMessage("Password da ən azı bir böyük hərf və rəqəm olmalıdır");
        }
    }
}
