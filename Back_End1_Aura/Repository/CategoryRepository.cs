using Back_End1_Aura.Models;
using Back_End1_Aura.Data;
using System.Collections.Generic;
using System.Linq;

namespace Back_End1_Aura.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TaskDbContext _context;

        public CategoryRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryModel> GetAll() =>
            _context.Categories.ToList();

        public void Add(CategoryModel category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}