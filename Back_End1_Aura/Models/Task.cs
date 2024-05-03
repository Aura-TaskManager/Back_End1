using System.ComponentModel.DataAnnotations;

namespace Back_End1_Aura.Models
{
    public class ToDoTask
    {
        public int TaskId { get; set; } // Primary Key

        [Required]
        [StringLength(255)] // Maximum length of Description is 255 characters
        public string Description { get; set; } = ""; // Initialized with an empty string

        public DateTime CreationDate { get; set; } // Not null
        public DateTime DueDate { get; set; } // Not null
        public bool Status { get; set; } // Not null
    }
}