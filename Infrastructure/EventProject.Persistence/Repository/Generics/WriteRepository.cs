using EventProject.Application.Repositories;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EventProject.Persistence.Repository.Generics;

public class WriteRepository<TEntity>(AppDbContext context) : IWriteRepository<TEntity> where TEntity : BaseEntity
{

	private readonly AppDbContext context = context;

	public DbSet<TEntity> Table => context.Set<TEntity>();

	public async Task<bool> AddAsync(TEntity entity)
	{
		var result= await Table.AddAsync(entity);
		return result.State == EntityState.Added;
	}

	public async Task<bool> AddRangeAsync(IEnumerable<TEntity> entities)
	{
	    await Table.AddRangeAsync(entities);
		return true;	

	}

	public  bool Delete(TEntity entity)
	{
		var result=Table.Remove(entity);
		return result.State == EntityState.Deleted;
	}

	public async Task<bool> DeleteAsync(string id)
	{
		var result = await Table.FirstOrDefaultAsync(T => Guid.Parse(id)==T.Id);
		return Delete(result);
	}


	public bool DeleteRange(IEnumerable<TEntity> entities)
	{
		Table.RemoveRange(entities);
		return true;

	}

	public Task<int> SaveChangesAsync()=>context.SaveChangesAsync();


	public async Task<bool> UpdateAsync(TEntity entity)
	{
		var result=await UpdateAsync(entity);
		return result;
	}

	
}
