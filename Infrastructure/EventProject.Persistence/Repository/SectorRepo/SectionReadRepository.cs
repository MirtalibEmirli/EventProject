using EventProject.Application.Repositories.SectionRepo;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.SectorRepo;



public class SectionReadRepository : ReadRepository<Section>, ISectionReadRepository
{
    public SectionReadRepository(AppDbContext context) : base(context)
    {
    }
}
