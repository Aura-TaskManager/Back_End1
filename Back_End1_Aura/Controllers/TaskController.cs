using Back_End1_Aura.Service;
using Back_End1_Aura.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Back_End1_Aura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService) => _taskService = taskService;

        [HttpGet("{name}")]
        public TaskViewModel GetByName(string name) => _taskService.GetByName(name);

        [HttpGet ("GetAll")]
        public IEnumerable<TaskViewModel> GetAll() => _taskService.GetAll();
    }
}