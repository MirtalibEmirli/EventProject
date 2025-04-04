using EventProject.Application.Repositories.Users;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Users;

public class UserReadRepository : ReadRepository<User>, IUserReadRepsoitory
{
	public UserReadRepository(AppDbContext context) : base(context)
	{


	}
}
