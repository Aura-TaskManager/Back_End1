using System;
using System.ComponentModel.DataAnnotations;

namespace Back_End1_Aura.Models
{
    public class ToDoTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        public int StatusId { get; set; } // Foreign key
        public Status Status { get; set; } = null!;
    }
}