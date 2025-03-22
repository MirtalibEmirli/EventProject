using EventProject.Application.Repositories.Seats;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Seats;

public class SeatWriteRepository : WriteRepository<Seat>, ISeatWriteRepository
{
    public SeatWriteRepository(AppDbContext context) : base(context)
    {
    }
}
