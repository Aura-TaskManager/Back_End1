using Back_End1_Aura.Models;
using Back_End1_Aura.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Back_End1_Aura.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskModel> GetAll() =>
            _context.Tasks.Include(t => t.TaskCategories).ThenInclude(tc => tc.Category).ToList();

        public void Add(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}