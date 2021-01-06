using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Repositories
{
    public class ImageRepository : GenericRepository<Image>
    {
        public ImageRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}