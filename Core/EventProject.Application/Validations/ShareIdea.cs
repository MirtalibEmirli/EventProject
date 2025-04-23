using EventProject.Application.Features.Commands.SendPartyIdeaCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Validations;

class ShareIdea:AbstractValidator<SendPartyIdeaRequest>
{
    public ShareIdea()
    {

        RuleFor(x => x.Email).EmailAddress();

    }
}
