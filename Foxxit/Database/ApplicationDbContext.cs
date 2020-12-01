using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Foxxit.Database
{
    public class ApplicationDbContext : IdentityDbContext<FoxxitUser>
    {
        public DbSet<FoxxitUser> FoxxitUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SubReddit> SubReddits { get;set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        //backing DbSet, maybe it is not necessary to access directly
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
            modelBuilder.Entity<PostBase>()
                .Property(p => p.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubReddit>()
                .Property(s => s.CreatedAt)
                .ValueGeneratedOnAdd();

            //Relations setup

            //Join table for User/Subreddit
            modelBuilder.Entity<FoxxitUserSubReddit>()
                .HasKey(fs => new {fs.FoxxitUserId, fs.SubRedditId});

            //Vote
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

            //Comment
            modelBuilder.Entity<Comment>()
                .HasOne(u => u.Owner)
                .WithMany(c => c.Comments)
                .HasForeignKey(u => u.FoxxitUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            //Post
            modelBuilder.Entity<Post>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.Post)
                .HasForeignKey(p => p.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>()
                .HasOne(u => u.Owner)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.FoxxitUserId)
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