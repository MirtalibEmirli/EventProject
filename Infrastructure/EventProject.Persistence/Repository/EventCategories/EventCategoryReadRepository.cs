using EventProject.Application.Repositories.EventCategories;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.EventCategories;

public class EventCategoryReadRepository(AppDbContext context) : ReadRepository<Category>(context) ,IEventCategoryReadRepository
{
}
