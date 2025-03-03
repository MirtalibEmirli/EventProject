namespace EventProject.Application.Repositories.Events;

public interface IEventReadRepository<T> : IReadRepository<T>  where T :Event, new()
{

}
