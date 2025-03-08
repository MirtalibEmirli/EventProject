using EventProject.Application.Repositories.Notifilications;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Notifilications;

public class NotifilicationReadRepository : ReadRepository<Notification>,INotifilicationReadRepository
{
    public NotifilicationReadRepository(AppDbContext context) : base(context)
    {
    }
}
