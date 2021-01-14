using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class CommentRepository : GenericRepository<Comment>
    {
        private readonly DbSet<Comment> table;

        public CommentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            table = dbContext.Set<Comment>();
        }

        public async Task<Comment> GetByIdInclude(long id)
        {
            return await table.Include(c => c.Comments).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}