using Microsoft.EntityFrameworkCore;
using Back_End1_Aura.Models;

namespace Back_End1_Aura.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.TaskId);
        }
    }
}