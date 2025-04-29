using EventProject.Application.Features.Commands.UserCommands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Validations
{
    public class RegisterValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
                RuleFor(x=>x.Email).NotEmpty().EmailAddress().WithMessage("Gmail addresi daxil edin");
            RuleFor(x=>x.Firstname).NotEmpty().MinimumLength(3).WithMessage("Ad minimum 3 simvol olmalidir");
            RuleFor(x=>x.Password).NotEmpty().MinimumLength(8).WithMessage("Password minimum 8 simvol olmaldir!").
                Must(password=>password.Any(char.IsDigit)&&password.Any(char.IsUpper)).WithMessage("Password da ən azı bir böyük hərf və rəqəm olmalıdır");
        }
    }
}
