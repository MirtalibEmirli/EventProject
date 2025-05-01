using EventProject.Application.Repositories.Comments;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Comments;

public class CommentReadRepository : ReadRepository<Comment>, ICommentReadRepository
{
	public CommentReadRepository(AppDbContext context) : base(context)
	{
	}
}
