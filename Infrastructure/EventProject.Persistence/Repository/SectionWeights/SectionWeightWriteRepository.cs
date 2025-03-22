using EventProject.Application.Repositories.SectionWeights;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.SectionWeights;

public class SectionWeightWriteRepository : WriteRepository<SectionWeight>, ISectionWeightWriteRepository
{
    public SectionWeightWriteRepository(AppDbContext context) : base(context)
    {
    }
}
