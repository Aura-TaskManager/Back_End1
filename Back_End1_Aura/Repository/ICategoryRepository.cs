using Back_End1_Aura.Models;
using System.Collections.Generic;

namespace Back_End1_Aura.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> GetAll();
        void Add(CategoryModel category);
    }
}