using Back_End1_Aura.Controllers;
using Back_End1_Aura.Service;
using Back_End1_Aura.Models;
using Back_End1_Aura.Repository;
using Back_End1_Aura.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Back_End1_Aura.Tests
{
    [TestClass]
    public class TaskControllerTest
    {
        [TestMethod]
        public void GetAll_ShouldReturnAllTasks()
        {
            // Arrange
            var mockTaskRepository = new Mock<ITaskRepository>();
            mockTaskRepository.Setup(repo => repo.GetAll())
                .Returns(GetSampleTaskModels());

            var mockCategoryRepository = new Mock<ICategoryRepository>(); // Mock the category repository

            var taskService = new TaskService(mockTaskRepository.Object, mockCategoryRepository.Object);
            var controller = new TaskController(taskService);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<TaskViewModel>));
            Assert.AreEqual(2, result.Count());
        }

        private IEnumerable<TaskModel> GetSampleTaskModels()
        {
            return new List<TaskModel>
            {
                new TaskModel { TaskId = 1, Name = "Task 1" },
                new TaskModel { TaskId = 2, Name = "Task 2" }
            };
        }
    }
}