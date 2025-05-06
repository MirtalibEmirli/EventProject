using EventProject.Application.Repositories.StandingZones;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.StandingZones
{
    public class StandingZoneReadRepository : ReadRepository<StandingZone>, IStandingZoneReadRepository
    {
        public StandingZoneReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
