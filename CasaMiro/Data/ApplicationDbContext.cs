using CasaMiro.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaMiro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ForumPost> ForumPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; } // New table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne<ForumPost>()
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ForumPostId);

            modelBuilder.Entity<Reply>()
               .HasOne<ForumPost>()
               .WithMany(p => p.Replies)
               .HasForeignKey(r => r.ForumPostId);

            // Configure ServiceRequest relationship
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.User)
                .WithMany() // No navigation property on User
                .HasForeignKey(sr => sr.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Delete requests if user is deleted

            // Ensure RequestId is unique
            modelBuilder.Entity<ServiceRequest>()
                .HasIndex(sr => sr.RequestId)
                .IsUnique();
        }
    }
}
