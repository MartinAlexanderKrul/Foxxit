using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Repositories
{
    public class ImageRepository : GenericRepository<Image>
    {
        private readonly DbSet<Image> table;

        public ImageRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            table = dbContext.Set<Image>();
        }

        public async Task<Image> GetByNameAsync(string name)
        {
            return await table.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}