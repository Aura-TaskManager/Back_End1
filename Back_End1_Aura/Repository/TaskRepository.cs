using Back_End1_Aura.Models;
using Back_End1_Aura.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_End1_Aura.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context) // Change DbContext to AppDbContext
        {
            _context = context;
        }

        public TaskModel GetByName(string name)
        {
            return _context.Tasks.SingleOrDefault(task => task.Name == name);
        }

        public IEnumerable<TaskModel> GetAll()
        {
            return _context.Tasks.ToList();
        }
    }
}