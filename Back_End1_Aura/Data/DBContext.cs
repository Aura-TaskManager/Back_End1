using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Back_End1_Aura.Models;
using System.IO;

namespace Back_End1_Aura.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.TaskId);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Status>()
                .HasKey(s => s.StatusId);

            modelBuilder.Entity<ToDoTask>()
                .HasMany(t => t.Categories)
                .WithMany(c => c.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskCategory",
                    j => j.HasOne<Category>().WithMany().HasForeignKey("CategoryId"),
                    j => j.HasOne<ToDoTask>().WithMany().HasForeignKey("TaskId"),
                    j =>
                    {
                        j.HasKey("TaskId", "CategoryId");
                    });

            modelBuilder.Entity<ToDoTask>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Tasks)
                .HasForeignKey(t => t.StatusId);
        }
    }
}

//migration updaten met: dotnet ef database update --project Back_End1_Aura/Back_End1_Aura.csproj
//migration maken met: dotnet ef migrations add InitialCreate
//voorbeeld migration updaten: dotnet ef migrations add /nieuwe entity/