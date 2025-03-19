using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.EventMediaFiles;

public class EventMediaFileWriteRepository:WriteRepository<EventMediaFile>,IEventMediaFileWriteRepository
{
    public EventMediaFileWriteRepository(AppDbContext appDbContext):base(appDbContext) 
    {

    }
}
