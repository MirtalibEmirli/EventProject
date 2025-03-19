

using EventProject.Application.Repositories.Events;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Events;

public class EventReadRepository : ReadRepository<Event>, IEventReadRepository
{
	public EventReadRepository(AppDbContext context) : base(context)
	{

	}
}
