using Microsoft.EntityFrameworkCore;
using Task12.Models;

namespace Task12.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<TaskItem> TaskItem { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasOne(t => t.User).WithMany(t => t.TaskItems).HasForeignKey(t => t.UserId);

            });

            base.OnModelCreating(modelBuilder);
        }
    }

}
