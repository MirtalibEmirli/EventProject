using EventProject.Application.Features.Commands.UserCommands.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Validations
{
    public class LoginValidator:AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty().MinimumLength(4);
        }
    }
}
