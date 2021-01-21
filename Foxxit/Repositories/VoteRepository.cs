using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Repositories
{
    public class VoteRepository : GenericRepository<Vote>
    {
        public VoteRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}