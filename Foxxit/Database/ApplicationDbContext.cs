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
                .Property(pb => pb.CreatedAt)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubReddit>()
                .Property(sr => sr.CreatedAt)
                .ValueGeneratedOnAdd();

            // Relations setup

            // Join table for User/Subreddit
            modelBuilder.Entity<UserSubReddit>()
                .HasKey(usr => new { usr.UserId, usr.SubRedditId });

            // Vote
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Owner)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.FoxxitUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Postbase)
                .WithMany(pb => pb.Votes)
                .HasForeignKey(v => v.PostBaseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Post
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>()
                .HasOne(p => p.SubReddit)
                .WithMany(sr => sr.Posts)
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