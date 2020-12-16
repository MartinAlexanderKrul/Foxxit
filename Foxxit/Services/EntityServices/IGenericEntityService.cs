using Foxxit.Models.Entities;
using Foxxit.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foxxit.Services.EntityServices
{
    public interface IGenericEntityService<T> where T : class, IIdentityEntity
    {
        GenericRepository<T> Repository { get; set; }

        void AddAsync(T entity);
        void Delete(T entity);
        IEnumerable<T> Filter(Func<T, bool> condition);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        void SaveAsync();
        void Update(T entity);
    }
}