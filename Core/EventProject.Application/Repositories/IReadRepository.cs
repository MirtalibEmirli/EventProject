﻿using EventProject.Domain.Entities;
using System.Linq.Expressions;

namespace EventProject.Application.Repositories;
public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
     Task<IEnumerable<T>> GetAllAsync();
     Task<T> GetByIdAsync(string id);
     IEnumerable<T> GetWhere(Expression<Func<T, bool>> method);
     Task<T> GetSingleWhereAsync(Expression<Func<T,bool>>filter=null);

}
