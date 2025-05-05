using EventProject.Application.Abstractions.Jobs;
using EventProject.Application.Repositories.UserRwEvents;

namespace EventProject.Application.Services.Jobs;

public class RecentlyViewedJob(IUserRwEventsReadRepository readRepo,
    IUserRwEventsWriteRepository writeRepo) : IRecentlyViewedJob
{
    public async Task DeleteOldRecentlyViewedEvents()
    {
        var twodaysago = DateTime.Now.AddDays(-2);
        var pasrtRecentlyvieweds = readRepo.GetWhere(rw => rw.IsDeleted != true && rw.CreatedDate <= twodaysago);
        writeRepo.DeleteRange(pasrtRecentlyvieweds);
        await writeRepo.SaveChangesAsync();

    }
}
