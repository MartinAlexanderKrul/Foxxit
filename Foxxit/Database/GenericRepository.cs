using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

//Exception handling is to be made on the service layer
namespace Foxxit.Database
{
    public class GenericRepository<T> where T : class
    {
        //dependency injection
        private readonly ApplicationDbContext dbContext = null;
        //for being able to define which table to modify or get data from
        private readonly DbSet<T> table = null;

        public GenericRepository()
        {
            dbContext = new ApplicationDbContext();
            table = dbContext.Set<T>();
        }

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            table = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        //object id lets us use different id types
        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        //!!WARNING this one seems a bit different I've used in Java
        public void Update(T obj)
        {
            table.Attach(obj);
            dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}