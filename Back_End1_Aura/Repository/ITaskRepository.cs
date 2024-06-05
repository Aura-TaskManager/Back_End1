using Back_End1_Aura.Models;
using System.Collections.Generic;

namespace Back_End1_Aura.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAll();
        void Add(TaskModel task);
    }
}