using EventProject.Domain.Entities;

namespace EventProject.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
{

}
