using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.UserRwEvents;

public class UserRwEventsWriteRepository:WriteRepository<UserRwEvent>,IUserRwEventsWriteRepository
{
    private AppDbContext _context ;   
    public UserRwEventsWriteRepository(AppDbContext appDbContext):base(appDbContext)
    {
        _context = appDbContext;
    }

    public async Task DeleteRangeHardAsync(IEnumerable<UserRwEvent> entities)
    {
        _context.Set<UserRwEvent>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

}
