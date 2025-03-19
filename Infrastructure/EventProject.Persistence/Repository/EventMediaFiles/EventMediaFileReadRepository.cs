using EventProject.Application.Repositories;
using EventProject.Application.Repositories.EventMediaFiles;
using EventProject.Application.Repositories.Events;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using Microsoft.EntityFrameworkCore;


namespace EventProject.Persistence.Repository.EventMediaFiles;

public class EventMediaFileReadRepository : ReadRepository<EventMediaFile>, IEventMediaFileReadRepository
{
    public EventMediaFileReadRepository(AppDbContext dbContext):base(dbContext) 
    {

    }
}
