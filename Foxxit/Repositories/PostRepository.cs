using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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