using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class UserSubRedditRepository : GenericRepository<UserSubReddit>
    {
        private readonly DbSet<UserSubReddit> table;

        public UserSubRedditRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            table = dbContext.Set<UserSubReddit>();
        }

        public UserSubReddit GetByOthersId(long subRedditId, long userId)
        {
            return table.FirstOrDefault(usr => usr.SubRedditId == subRedditId && usr.UserId == userId);
        }

        public async Task Delete(long subRedditId, long userId)
        {
            table.Remove(GetByOthersId(subRedditId, userId));
            await SaveAsync();
        }
    }
}