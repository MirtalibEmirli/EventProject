using EventProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventProject.Application.Repositories;

public interface IRepository<T> where T : class
{
    public DbSet<T> Table { get;  }
}
