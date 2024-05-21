using System.ComponentModel.DataAnnotations;

namespace Back_End1_Aura.Models
{ 
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}