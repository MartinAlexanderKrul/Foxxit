using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Repositories
{
    public class SubRedditRepository : GenericRepository<SubReddit>
    {
        public SubRedditRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}