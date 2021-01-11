using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class SubRedditRepository : GenericRepository<SubReddit>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<SubReddit> table;

        public SubRedditRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
            table = dbContext.Set<SubReddit>();
        }

        public async Task<IEnumerable<SubReddit>> GetAllIncludeUser()
        {
            return await table.Include(u => u.CreatedBy).ToListAsync();
        }

        public SubReddit GetByIdAsyncIncludeUser(long id)
        {
            return GetAllIncludeUser().Result.FirstOrDefault(s => s.Id == id);
        }
    }
}