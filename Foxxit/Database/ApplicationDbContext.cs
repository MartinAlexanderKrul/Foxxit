using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foxxit.Database
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<Entity> Entities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}