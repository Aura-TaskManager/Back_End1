namespace Back_End1_Aura.Models
{
    public class TaskCategoryModel
    {
        public int TaskId { get; set; }
        public TaskModel Task { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}