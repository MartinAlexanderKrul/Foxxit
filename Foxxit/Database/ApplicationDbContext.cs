using Foxxit.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Foxxit.Database
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<SubReddit> SubReddits { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // backing DbSet, maybe it is not necessary to access directly
        public DbSet<UserSubReddit> UserSubReddits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Generate Timestamps on first save
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
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
                .HasKey(us => new { us.UserId, us.SubRedditId });

            // Vote
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Owner)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.FoxxitUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Postbase)
                .WithMany(pb => pb.Votes)
                .HasForeignKey(v => v.PostBaseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            // Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            // Post
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.SubReddit)
                .WithMany(s => s.Posts)
                .HasForeignKey(p => p.SubRedditId)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasData(new IdentityRole("Admin"));
            modelBuilder.Entity<User>()
                .HasData(new IdentityRole("User"));
        }
    }
}