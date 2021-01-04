using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services.EntityServices
{
    public interface IGenericEntityService<T>
        where T : class, IIdentityEntity
    {
        Task AddAsync(T entity);

        void Delete(T entity);

        IEnumerable<T> Filter(Func<T, bool> condition);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(long id);

        Task SaveAsync();

        void Update(T entity);
    }
}