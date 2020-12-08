using System.Collections.Generic;
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

        public async Task<T> GetByIdAsync(long id)
        {
            return await table.FindAsync(id);
        }

        public async void AddAsync(T entity)
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

        public async void SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}