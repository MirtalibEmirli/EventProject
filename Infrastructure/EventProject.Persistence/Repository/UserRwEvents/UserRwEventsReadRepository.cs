using EventProject.Application.Repositories.UserRwEvents;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.UserRwEvents
{
    public class UserRwEventsReadRepository:ReadRepository<UserRwEvent>,IUserRwEventsReadRepository
    {
        public UserRwEventsReadRepository(AppDbContext appDbContext):base(appDbContext) 
        {
            
        }
    }
}
