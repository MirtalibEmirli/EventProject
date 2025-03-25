using EventProject.Application.Repositories;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

	//public  bool Delete(TEntity entity)
	//{
	//	var result=Table.Remove(entity);
	//	return result.State == EntityState.Deleted;
	//}

	//public async Task<bool> DeleteAsync(string id)
	//{
	//	var result = await Table.FirstOrDefaultAsync(T => Guid.Parse(id)==T.Id);
	//	return Delete(result);
	//}


	public bool DeleteRange(IEnumerable<TEntity> entities)
	{
		if (entities is not null)
		{
			foreach (var item in entities)
			{
				if (item is not null)
				{
					item.IsDeleted = true;
					item.DeletedDate= DateTime.Now;
				}
				else return false;
			}
			return true;
		}
		return false;

	}

	public Task<int> SaveChangesAsync()=> context.SaveChangesAsync();






    public async Task<bool> SoftDeleteAsync(string id)
	{
		var entity = await Table.FirstOrDefaultAsync(e => e.Id==Guid.Parse(id));
		if(entity is not null)
		{
			entity.DeletedDate=DateTime.Now;
			entity.IsDeleted=true;
			return true;
		}
		return false;
	}

	public  bool Update(TEntity entity)
	{
		var result= Table.Update(entity);
		entity.UpdatedDate= DateTime.Now;	
		return result.State==EntityState.Modified;
	}

	
}
