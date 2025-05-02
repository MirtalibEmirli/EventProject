using EventProject.Application.Repositories.Events;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System.Linq.Expressions;

namespace EventProject.Persistence.Repository.Events;

public class EventWriteRepository : WriteRepository<Event>,IEventWriteRepository
{
	public EventWriteRepository(AppDbContext context) : base(context)
	{
	}

	
}
