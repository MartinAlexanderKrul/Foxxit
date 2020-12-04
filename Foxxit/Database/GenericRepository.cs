using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Database
{
    public class GenericRepository<T> where T : IEntity
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

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Update(obj);
        }

        public void Delete(T obj)
        {
            table.Remove(obj);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}