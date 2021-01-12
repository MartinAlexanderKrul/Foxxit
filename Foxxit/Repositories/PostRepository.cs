using System.Collections.Generic;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        private readonly DbSet<Post> table;

        public PostRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            table = dbContext.Set<Post>();
        }

        public async Task<IEnumerable<Post>> GetAllIncludeCommentsAndUserAsync()
        {
            return await table.Include(p => p.User).Include(p => p.Comments).ThenInclude(c => c.User).ToListAsync();
        }
    }
}