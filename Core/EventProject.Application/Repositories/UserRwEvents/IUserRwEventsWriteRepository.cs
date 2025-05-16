using EventProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Repositories.UserRwEvents
{
    public interface IUserRwEventsWriteRepository:IWriteRepository<UserRwEvent>
    {
        public Task DeleteRangeHardAsync(IEnumerable<UserRwEvent> entities);

    }
}
