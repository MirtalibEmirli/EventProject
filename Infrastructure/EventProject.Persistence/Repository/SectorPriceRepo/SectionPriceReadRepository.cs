using EventProject.Application.Repositories.SectionPriceRepo;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.SectorPriceRepo;

public class SectionPriceReadRepository:ReadRepository<SectionPrice>,ISectionPriceReadRepository
{
    public SectionPriceReadRepository(AppDbContext dbContext) : base(dbContext) { }
}
