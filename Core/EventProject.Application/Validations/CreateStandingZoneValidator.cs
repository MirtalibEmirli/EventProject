using EventProject.Application.Features.Commands.EventStandingZoneCommand.CreateStandingZone;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Validations;

public class CreateStandingZoneValidator:AbstractValidator<CreateStandingZoneRequest>
{

    public CreateStandingZoneValidator()
    {
        RuleFor(x=>x.ZoneName).IsInEnum().WithMessage("ZoneName etibarli bir enum deyeri olmalidir");
        RuleFor(x => x.Capacity).GreaterThan(0);
    }
}
