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
            return await table.Include(s => s.Posts).ThenInclude(p => p.Comments).Include(s => s.Posts).ThenInclude(p => p.User).Include(s => s.CreatedBy).Include(s => s.Members).ThenInclude(m => m.User).ToListAsync();
        }

        public async Task<SubReddit> GetByIdIncludeUserAndMembers(long id)
        {
            var table = await GetAllIncludeUserAndMembers();
            return table.FirstOrDefault(s => s.Id == id);
        }
    }
}