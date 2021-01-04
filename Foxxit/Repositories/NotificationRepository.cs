using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Database;
using Foxxit.Models.Entities;

namespace Foxxit.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>
    {
        public NotificationRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}