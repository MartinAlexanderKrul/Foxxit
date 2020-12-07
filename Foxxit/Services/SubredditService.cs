using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Services
{
    public class SubredditService
    {
        private readonly ApplicationDbContext dbContext;
        public SubredditService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SubReddit> FindById(long id)
        {
            var subreddit = new SubReddit();
            return subreddit;
        }
    }
}
