using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Repositories.Venues;

public class VenueWriteRepository : WriteRepository<Venue>, IVenueWriteRepository
{
    public VenueWriteRepository(AppDbContext context) : base(context)
    {
    }
}
