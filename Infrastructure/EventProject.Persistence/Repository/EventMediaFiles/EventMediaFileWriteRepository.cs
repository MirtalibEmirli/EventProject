using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Persistence.Repository.EventMediaFiles;

public class EventMediaFileWriteRepository : WriteRepository<EventMediaFile>, IEventMediaFileWriteRepository
{
    private readonly AppDbContext _appDbContext;
    public EventMediaFileWriteRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SoftDeleteAsyncByName(string fileName)
    {
        var table = _appDbContext.Set<EventMediaFile>();

        var entity = await table.FirstOrDefaultAsync(x => x.FileName == fileName);
        if (entity != null)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            table.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
