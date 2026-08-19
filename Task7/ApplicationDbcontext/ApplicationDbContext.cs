using Microsoft.EntityFrameworkCore;
using Task7.Models;

namespace Task7.ApplicationDbcontext
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<TaskItem> TaskItems;
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasKey(t=> t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).IsRequired().HasMaxLength(200);

                entity.HasOne(t=>t.User).WithMany(u=>u.TaskItems).HasForeignKey(t=>t.UserId);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
            
        }

    }
}
