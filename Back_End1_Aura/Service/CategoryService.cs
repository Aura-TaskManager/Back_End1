using Back_End1_Aura.Models;
using Back_End1_Aura.Data;
using System.Collections.Generic;
using System.Linq;
using Back_End1_Aura.Repository;

namespace Back_End1_Aura.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryModel> GetAll() =>
            _categoryRepository.GetAll();

        public void AddCategory(CategoryModel category)
        {
            _categoryRepository.Add(category);
        }
    }
}