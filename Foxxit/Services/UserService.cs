using Foxxit.Database;
using Foxxit.Models.Entities;
using Foxxit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Services
{
    public class UserService
    {
        public ApplicationDbContext DbContext { get; private set; }

        public UserService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}