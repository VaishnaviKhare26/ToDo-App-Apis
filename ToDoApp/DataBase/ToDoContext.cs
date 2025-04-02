
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataBase;
public class ToDoContext(DbContextOptions<ToDoContext> options) : DbContext(options)
{
    public DbSet<ToDoItems> ToDoItems { get; set; }
    public DbSet<LoginCreds> LoginCreds { get; set; }
}
