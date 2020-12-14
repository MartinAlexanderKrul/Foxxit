using System.Collections.Generic;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Database
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

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public T GetById(long id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}