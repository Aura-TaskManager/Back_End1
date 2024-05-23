namespace Back_End1_Aura.Models;

public class CategoryModel
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}