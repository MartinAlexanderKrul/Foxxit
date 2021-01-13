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
        private readonly DbSet<SubReddit> table;

        public SubRedditRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            table = dbContext.Set<SubReddit>();
        }

        public async Task<IEnumerable<SubReddit>> GetAllIncludeUserAndMembers()
        {
            return await table.Include(s => s.CreatedBy).Include(s => s.Members).ThenInclude(m => m.User).ToListAsync();
        }

        public SubReddit GetByIdIncludeUserAndMembers(long id)
        {
            return GetAllIncludeUserAndMembers().Result.FirstOrDefault(s => s.Id == id);
        }
    }
}