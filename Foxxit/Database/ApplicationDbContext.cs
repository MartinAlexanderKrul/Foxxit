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
        public DbSet<FoxxitUser> FoxxitUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SubReddit> SubReddits { get;set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<FoxxitUserSubReddit> FoxxitUserSubReddits { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Generate Timestamps on first save
            modelBuilder.Entity<FoxxitUser>()
                .Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubReddit>()
                .Property(s => s.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .ValueGeneratedOnAdd();

            //Relations setup

            //Join table for User/Subreddit
            modelBuilder.Entity<FoxxitUserSubReddit>().HasKey(fs => new {fs.FoxxitUserId, fs.SubRedditId});

            //Vote
            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Post)
                .WithMany(v => v.Votes)
                .HasForeignKey(p => p.PostId);
            modelBuilder.Entity<Vote>()
                .HasOne(c => c.Comment)
                .WithMany(v => v.Votes)
                .HasForeignKey(c => c.CommentId);
            modelBuilder.Entity<Vote>()
                .HasOne(u => u.Owner)
                .WithMany(v => v.VotesGiven)
                .HasForeignKey(u => u.FoxxitUserId);

            //Comment
            modelBuilder.Entity<Comment>()
                .HasOne(u => u.Owner)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.FoxxitUserId);

            //Post
            modelBuilder.Entity<Post>()
                .HasOne(u => u.Owner)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.FoxxitUserId);
            modelBuilder.Entity<Post>()
                .HasOne(s => s.SubReddit)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.SubRedditId);

        }
    }
    
}