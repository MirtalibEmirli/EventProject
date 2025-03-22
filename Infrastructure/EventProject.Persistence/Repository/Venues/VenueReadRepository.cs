using EventProject.Application.Repositories.Venues;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.Venues;

public class VenueReadRepository : ReadRepository<Venue>, IVenueReadRepository
{
    public VenueReadRepository(AppDbContext context) : base(context)
    {
    }
}
