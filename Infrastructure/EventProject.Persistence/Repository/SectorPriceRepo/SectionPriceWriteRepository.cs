using EventProject.Application.Repositories.SectionPriceRepo;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.SectorPriceRepo
{
    public class SectionPriceWriteRepository : WriteRepository<SectionPrice>, ISectionPriceWriteRepository
    {
        public SectionPriceWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
