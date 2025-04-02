using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Model
{
    public class ToDoItemRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        [Required]
        public String Priority { get; set; } = string.Empty;

        public DateTime Duedate { get; set; }
    }
}
