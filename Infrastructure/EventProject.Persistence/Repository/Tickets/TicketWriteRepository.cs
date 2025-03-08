using EventProject.Application.Repositories.Tickets;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Tickets;



public class TicketWriteRepository : WriteRepository<Ticket>, ITicketWriteRepository
{
    public TicketWriteRepository(AppDbContext context) : base(context)
    {
    }
}
