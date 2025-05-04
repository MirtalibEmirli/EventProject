using EventProject.Application.Repositories.Refresh;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Refresh;

public class RefreshTokenWrite:WriteRepository<RefreshToken>,IRefreshTokenWrite
{
    public RefreshTokenWrite(AppDbContext dv):base(dv)
    {
        
    }
}
