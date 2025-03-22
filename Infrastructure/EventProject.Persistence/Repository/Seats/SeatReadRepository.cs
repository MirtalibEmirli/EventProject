using EventProject.Application.Repositories;
using EventProject.Application.Repositories.Seats;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.Seats;

public class SeatReadRepository : ReadRepository<Seat>,ISeatReadRepository
{
    public SeatReadRepository(AppDbContext context) : base(context)
    {
    }
}
