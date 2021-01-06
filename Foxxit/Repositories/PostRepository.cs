using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}