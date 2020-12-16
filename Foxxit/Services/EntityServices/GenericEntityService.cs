using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Foxxit.Repositories;

namespace Foxxit.Services.EntityServices
{
    public class GenericEntityService<T> : IGenericEntityService<T>
        where T : class, IIdentityEntity
    {
        public GenericEntityService(GenericRepository<T> repository)
        {
            Repository = repository;
        }

        public GenericRepository<T> Repository { get; set; }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public IEnumerable<T> Filter(Func<T, bool> condition)
        {
            return Repository.Filter(condition);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }

        public async Task SaveAsync()
        {
            await Repository.SaveAsync();
        }
    }
}