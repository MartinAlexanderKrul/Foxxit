using Foxxit.Database;
using Foxxit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Services
{
    public class Service : IService
    {
        public ApplicationDbContext DbContext { get; private set; }

        public Service(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}