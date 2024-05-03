using Microsoft.EntityFrameworkCore;
using Back_End1_Aura.Models;

namespace Back_End1_Aura.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=mssqlstud.fhict.local;Database=dbi502633_aura;User Id=dbi502633_aura;Password=aura123;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(t => t.TaskId);
        }
    }
}