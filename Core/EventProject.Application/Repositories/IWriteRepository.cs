using EventProject.Domain.Entities;

namespace EventProject.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
{
	Task<bool> AddAsync(T entity);
	Task<bool> AddRangeAsync(IEnumerable<T> entities);
	Task<bool> SoftDeleteAsync(string id);//cqrs
 	//bool Delete(T Entity);
	bool DeleteRange(IEnumerable<T> entities);
	bool Update(T entity);
	Task<int> SaveChangesAsync();

}
