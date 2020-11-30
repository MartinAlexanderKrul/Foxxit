using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;

namespace Foxxit.Database
{
    public class ApplicationDbContext : DbContext
    {
        // public DbSet<Entity> Entities { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoxxitUserSubReddit>().HasKey(fs => new {fs.FoxxitUserId, fs.SubRedditId});
            modelBuilder.Entity<Post>()
                .HasOne(u => u.Owner)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.FoxxitUserId);
            modelBuilder.Entity<Post>()
                .HasOne(s => s.SubReddit)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.SubredditId);
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Post)
                .WithMany(p => p.Votes)
                .HasForeignKey(p => p.PostId);
        }
    }
}