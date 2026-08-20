using Microsoft.EntityFrameworkCore;
using Task8.Models;

namespace Task8.ApplicationDbcontext
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("TaskItem");
                entity.HasKey(t=> t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(200);
                entity.Property(t => t.Description).IsRequired().HasMaxLength(200);
                entity.Property(t => t.IsCompleted).IsRequired().HasDefaultValue(false);

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
