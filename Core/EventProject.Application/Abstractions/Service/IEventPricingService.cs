using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Abstractions.Service;

public interface IEventPricingService
{
    Task AssiginPricesToSeatAsync(Event eventEntity);

}
