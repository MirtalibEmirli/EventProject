using EventProject.Application.Repositories;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventProject.Persistence.Repository.Generics;

public class ReadRepository<TEntity>(AppDbContext context) : IReadRepository<TEntity> where TEntity : BaseEntity
{
	private readonly AppDbContext _context = context;

	public DbSet<TEntity> Table=>_context.Set<TEntity>();

	public IEnumerable<TEntity> GetAll() =>  Table;

	public async Task<TEntity> GetByIdAsync(string id) => await Table.FirstOrDefaultAsync(T => T.Id==Guid.Parse(id));

	public async Task<TEntity> GetSingleWhereAsync(Expression<Func<TEntity, bool>> filter = null) => await Table.FirstOrDefaultAsync(filter);

	public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method) =>  Table.Where(method);
}

