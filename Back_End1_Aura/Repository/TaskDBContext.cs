using Microsoft.EntityFrameworkCore;
using Back_End1_Aura.Models;

namespace Back_End1_Aura.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TaskCategoryModel> TaskCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskCategoryModel>()
                .HasKey(tc => new { tc.TaskId, tc.CategoryId });

            modelBuilder.Entity<TaskCategoryModel>()
                .HasOne(tc => tc.Task)
                .WithMany(t => t.TaskCategories)
                .HasForeignKey(tc => tc.TaskId);

            modelBuilder.Entity<TaskCategoryModel>()
                .HasOne(tc => tc.Category)
                .WithMany(c => c.TaskCategories)
                .HasForeignKey(tc => tc.CategoryId);
        }
    }
}



//migration updaten met: dotnet ef database update --project Back_End1_Aura/Back_End1_Aura.csproj
//migration maken met: dotnet ef migrations add InitialCreate

//dotnet ef database update --project Back_End1_Aura/Back_End1_Aura.csproj
