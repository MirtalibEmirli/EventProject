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

    public IQueryable<TEntity> GetAll(bool tracking = true)
    {
        var query = Table.Where(x => x.IsDeleted != null);
        if (!tracking)
            query = query.AsNoTracking();

        return query;
    }


    public async Task<TEntity> GetByIdAsync(string id) => await Table.FirstOrDefaultAsync(T => T.Id==Guid.Parse(id) && T.IsDeleted!=true);


	public async Task<TEntity> GetSingleWhereAsync(Expression<Func<TEntity, bool>> filter = null) => await Table.Where(e=>e.IsDeleted!=true).FirstOrDefaultAsync(filter);


	public IEnumerable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method) => Table.Where(e => e.IsDeleted!=true).Where(method);

    public IQueryable<TEntity> GetWhereQuery(Expression<Func<TEntity, bool>> predicate) => Table.Where(e => e.IsDeleted != false).Where(predicate).AsQueryable();
}

