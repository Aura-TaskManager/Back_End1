namespace Back_End1_Aura.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
}