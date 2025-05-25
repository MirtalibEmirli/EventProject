
using EventProject.Application.Repositories.UserMediaFileRepo;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.UserMediaFileRepo
{
    public class UserMediaFileRead:ReadRepository<UserMediaFile>,IUserMediaFileRead
    {
        public UserMediaFileRead(AppDbContext context):base(context)
        {
            
        }
    }
}
