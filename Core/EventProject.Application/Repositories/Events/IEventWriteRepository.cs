using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Repositories.Events;

public interface IEventWriteRepository : IWriteRepository<Event>
{
    // Burada Event spesifik CRUD metodları olacaq
}

