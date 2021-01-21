using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Foxxit.Extensions;
using Foxxit.Models.Entities;
using Foxxit.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Foxxit.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<SubReddit> SubReddits { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // backing DbSet, maybe it is not necessary to access directly
        public DbSet<UserSubReddit> UserSubReddits { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            SoftDelete(markedAsDeleted);

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            SoftDelete(markedAsDeleted);

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // filters out Soft Deleted entities so they are acting as if they're deleted
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletable).IsAssignableFrom(type.ClrType) && type.BaseType == null)
                {
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
                }
            }

            // Generate Timestamps on first save
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<PostBase>()
                .Property(pb => pb.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SubReddit>()
                .Property(sr => sr.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Notification>()
                .Property(n => n.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            // Relations setup

            // Vote
            modelBuilder.Entity<Vote>()
                .HasOne(v => v.Owner)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.OwnerId)
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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Receiver)
                .WithMany(r => r.ReceivedNotifications)
                .HasForeignKey(n => n.ReceiverId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.Sender)
                .WithMany(s => s.GivenNotifications)
                .HasForeignKey(n => n.SenderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.PostBase);

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                });
            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole
                {
                    Id = 2,
                    Name = "User",
                    NormalizedName = "USER",
                });

            modelBuilder.Entity<SubReddit>()
                .HasOne(s => s.CreatedBy)
                .WithMany(u => u.CreatedSubReddits)
                .HasForeignKey(s => s.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            // Join table for User/Subreddit
            modelBuilder.Entity<UserSubReddit>()
                .HasKey(usr => new { usr.UserId, usr.SubRedditId });
            modelBuilder.Entity<UserSubReddit>()
                .HasOne(usr => usr.User)
                .WithMany(u => u.JoinedSubReddits)
                .HasForeignKey(usr => usr.UserId);
            modelBuilder.Entity<UserSubReddit>()
                .HasOne(usr => usr.SubReddit)
                .WithMany(u => u.Members)
                .HasForeignKey(usr => usr.SubRedditId);
        }

        private static void SoftDelete(IEnumerable<EntityEntry> entities)
        {
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    if (item.Entity is ISoftDeletable entity)
                    {
                        item.State = EntityState.Unchanged;
                        entity.IsDeleted = true;
                    }
                }
            }
        }
    }
}