using Back_End1_Aura.Models;
using Back_End1_Aura.Data;
using Microsoft.EntityFrameworkCore;

namespace Back_End1_Aura.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context) // database conn
        {
            _context = context;
        }
        
        public IEnumerable<TaskModel> GetAll()
        {
            return _context.Tasks.ToList();
        }
    }
}