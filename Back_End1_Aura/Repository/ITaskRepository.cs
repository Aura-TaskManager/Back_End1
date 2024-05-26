using Back_End1_Aura.Models;
namespace Back_End1_Aura.Data;

public interface ITaskRepository
{ 
    IEnumerable<TaskModel> GetAll();
}
