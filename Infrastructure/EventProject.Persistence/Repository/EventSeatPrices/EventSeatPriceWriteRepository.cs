using EventProject.Application.Repositories.EventSeatPrices;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.EventSeatPrices;

public class EventSeatPriceWriteRepository(AppDbContext context) : WriteRepository<EventSeatPrice>(context),IEventSeatPriceWriteRepository
{
}
