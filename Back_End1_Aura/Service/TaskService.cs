using Back_End1_Aura.Models;
using Back_End1_Aura.ViewModels;
using Back_End1_Aura.Data;
using System.Collections.Generic;
using System.Linq;

namespace Back_End1_Aura.Service
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository) => _taskRepository = taskRepository; //declare
        
        public IEnumerable<TaskViewModel> GetAll() => _taskRepository.GetAll().Select(task => MapToViewModel(task));

        private TaskViewModel MapToViewModel(TaskModel taskModel) => new TaskViewModel(taskModel.TaskId, taskModel.Name);
    }
}