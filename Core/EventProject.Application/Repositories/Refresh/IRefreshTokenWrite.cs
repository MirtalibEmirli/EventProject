using EventProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Repositories.Refresh
{
    public interface IRefreshTokenWrite:IWriteRepository<RefreshToken>
    {
    }
}
