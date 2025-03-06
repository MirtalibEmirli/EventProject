

using EventProject.Application.Repositories.Comments;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.Comments;

public class CommentWriteRepository : WriteRepository<Comment>, ICommentWriteRepository
{
	public CommentWriteRepository(AppDbContext context) : base(context)
	{
	}
}
