using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<Post> GetInclude()
        {
            return table
                .Include(p => p.Comments)
                .ThenInclude(c => c.Comments)
                .ThenInclude(c => c.Votes)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(p => p.Votes);
        }

        public async Task<IEnumerable<Post>> GetAllIncludeCommentsAndUserAsync()
        {
            return await GetInclude().ToListAsync();
        }

        public async Task<Post> GetByIdIncludeCommentsAndUserAsync(long id)
        {
            return await GetInclude().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}