using EventProject.Application.Repositories.Tickets;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.Tickets;

public class TicketReadRepository : ReadRepository<Ticket>, ITicketReadRepository
{
    public TicketReadRepository(AppDbContext context) : base(context)
    {
    }
}
