using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.DataBase
{
    [Table("ToDoItems")]
    public class ToDoItems
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        [Required]
        public String Priority { get; set; } = string.Empty;

        public DateTime Duedate { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}
