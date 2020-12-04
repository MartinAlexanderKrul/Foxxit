using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Database
{ 
    public class ApplicationDbContext : IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<SubReddit> SubReddits { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // backing DbSet, maybe it is not necessary to access directly
        public DbSet<UserSubReddit> UserSubReddits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Generate Timestamps on first save
            modelBuilder.Entity<User>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PostBase>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubReddit>()
                .Property(s => s.CreatedAt)
                .ValueGeneratedOnAdd();

            // Relations setup

            // Join table for User/Subreddit
            modelBuilder.Entity<UserSubReddit>()
                .HasKey(fs => new { fs.UserId, fs.SubRedditId });

            // Vote
            modelBuilder.Entity<Vote>()
                .HasOne(u => u.Owner)
                .WithMany(v => v.Votes)
                .HasForeignKey(u => u.FoxxitUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Postbase)
                .WithMany(v => v.Votes)
                .HasForeignKey(p => p.PostBaseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            // Comment
            modelBuilder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            // Post
            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>()
                .HasOne(u => u.User)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Post>()
                .HasOne(s => s.SubReddit)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.SubRedditId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}