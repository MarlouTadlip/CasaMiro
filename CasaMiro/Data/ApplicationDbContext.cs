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
        }
    }
}
