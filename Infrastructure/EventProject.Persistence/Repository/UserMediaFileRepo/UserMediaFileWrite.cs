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
    public class UserMediaFileWrite : WriteRepository<UserMediaFile>, IUserMediaFileWrite
    {
        public UserMediaFileWrite(AppDbContext context) : base(context)
        {
        }
    }
}
