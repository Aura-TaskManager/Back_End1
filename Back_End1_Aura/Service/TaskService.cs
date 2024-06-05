using Back_End1_Aura.Models;
using Back_End1_Aura.ViewModels;
using Back_End1_Aura.Data;
using System.Collections.Generic;
using System.Linq;
using Back_End1_Aura.Repository;

namespace Back_End1_Aura.Service
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TaskService(ITaskRepository taskRepository, ICategoryRepository categoryRepository)
        {
            _taskRepository = taskRepository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<TaskViewModel> GetAll() =>
            _taskRepository.GetAll().Select(task => MapToViewModel(task));

        public void AddTask(TaskViewModel taskViewModel, List<int> categoryIds)
        {
            var categories = _categoryRepository.GetAll().Where(c => categoryIds.Contains(c.CategoryId)).ToList();

            var task = new TaskModel
            {
                Name = taskViewModel.Name,
                TaskCategories = categories.Select(c => new TaskCategoryModel
                {
                    CategoryId = c.CategoryId,
                    Category = c // Ensure the category reference is set
                }).ToList()
            };

            _taskRepository.Add(task);
        }

        private TaskViewModel MapToViewModel(TaskModel taskModel) =>
            new TaskViewModel(taskModel.TaskId, taskModel.Name);
    }
}