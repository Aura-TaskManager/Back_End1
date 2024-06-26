﻿using Back_End1_Aura.Models;
using Back_End1_Aura.Repository;
using System.Collections.Generic;
using System.Linq;
using Back_End1_Aura.Data;

namespace Back_End1_Aura.Tests
{
    public class MockTaskRepository : ITaskRepository
    {
        private readonly List<TaskModel> _tasks;

        public MockTaskRepository()
        {
            _tasks = new List<TaskModel>
            {
                new TaskModel { TaskId = 1, Name = "Task 1" },
                new TaskModel { TaskId = 2, Name = "Task 2" }
            };
        }
        
        public IEnumerable<TaskModel> GetAll()
        {
            return _tasks;
        }

        public TaskModel GetByName(string name)
        {
            return _tasks.SingleOrDefault(task => task.Name == name);
        }
    }
}