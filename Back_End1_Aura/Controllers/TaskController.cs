using Back_End1_Aura.Service;
using Back_End1_Aura.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back_End1_Aura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService) => _taskService = taskService;

        [HttpGet("GetAll")]
        public IEnumerable<TaskViewModel> GetAll() => _taskService.GetAll();

        [HttpPost("AddTask")]
        public IActionResult AddTask([FromBody] AddTaskRequest request)
        {
            _taskService.AddTask(new TaskViewModel(0, request.Name), request.CategoryIds);
            return Ok();
        }
    }

    public class AddTaskRequest
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}