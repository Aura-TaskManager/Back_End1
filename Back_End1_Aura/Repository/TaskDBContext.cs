using Microsoft.EntityFrameworkCore;
using Back_End1_Aura.Models;

namespace Back_End1_Aura.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optionally configure your model further
            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            });
        }
    }
}


//migration updaten met: dotnet ef database update --project Back_End1_Aura/Back_End1_Aura.csproj
//migration maken met: dotnet ef migrations add InitialCreate
//voorbeeld migration updaten: dotnet ef migrations add /nieuwe entity/