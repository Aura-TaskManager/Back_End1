using Back_End1_Aura.Models;
using Back_End1_Aura.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back_End1_Aura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService) => _categoryService = categoryService;

        [HttpGet("GetAll")]
        public IEnumerable<CategoryModel> GetAll() => _categoryService.GetAll();

        [HttpPost("AddCategory")]
        public IActionResult AddCategory([FromBody] CategoryModel category)
        {
            _categoryService.AddCategory(category);
            return Ok();
        }
    }
}