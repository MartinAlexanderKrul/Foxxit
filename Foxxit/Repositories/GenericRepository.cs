using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class GenericRepository<T>
        where T : class, IIdentityEntity
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<T> table;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            table = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public IEnumerable<T> Filter(Func<T, bool> condition)
        {
            return table.Where(condition);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await table.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        //public async Task<int> FindByUserId(long id)
        //{
        //    await dbContext.FindAsync(id)
        //}
    }
}