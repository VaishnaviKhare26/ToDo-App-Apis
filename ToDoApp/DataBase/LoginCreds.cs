using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.DataBase
{
    [Table("LoginCreds")]
    public class LoginCreds
    {
        [Key]
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Password { get; protected set; } = string.Empty;

    }
}
