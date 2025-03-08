using EventProject.Application.Repositories.EventCategories;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.EventCategories;

public class EventCategoryWriteRepository : WriteRepository<Category>, IEventCategoryWriteRepository
{
	public EventCategoryWriteRepository(AppDbContext context) : base(context)
	{
	}
}
