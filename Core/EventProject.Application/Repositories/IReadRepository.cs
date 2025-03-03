using EventProject.Domain.Entities;

namespace EventProject.Application.Repositories;
public interface IReadRepository<T> :IRepository<T> where T : BaseEntity
{
      

}
