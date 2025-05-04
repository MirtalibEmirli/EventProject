using EventProject.Application.Repositories;
using EventProject.Application.Repositories.Refresh;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.Refresh
{
    public class RefreshTokenRead:ReadRepository<RefreshToken>,IRefreshTokenRead
    {
        public RefreshTokenRead(AppDbContext appDbContext):base(appDbContext)
        {
            
        }
    }
}
