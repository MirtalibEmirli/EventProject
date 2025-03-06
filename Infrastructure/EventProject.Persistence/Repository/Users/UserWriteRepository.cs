using EventProject.Application.Repositories.Users;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Users;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
	public UserWriteRepository(AppDbContext context) : base(context)
	{
	}
}
