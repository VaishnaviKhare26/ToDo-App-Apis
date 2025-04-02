using Microsoft.EntityFrameworkCore;
using ToDoApp.DataBase;


namespace ToDoApp.Model
{
    public class DBHelper
    {
        private readonly ToDoContext todoContext;

        public DBHelper(ToDoContext todoContext)
        {
            this.todoContext = todoContext;
        }

        /// <summary>
        /// Add a new ToDoItem to the database
        /// </summary>
        /// <param name="toDoItemRequestModel"></param>
        /// <returns></returns>
        public async Task AddToDoItem(ToDoItemRequestModel toDoItemRequestModel)
        {
            var toDoItem = new ToDoItems
            {
                Id = toDoItemRequestModel.Id,
                Title = toDoItemRequestModel.Title,
                Description = toDoItemRequestModel.Description,
                IsDone = toDoItemRequestModel.IsDone,
                Priority = toDoItemRequestModel.Priority,
                Duedate = toDoItemRequestModel.Duedate.ToUniversalTime()
            };
            await todoContext.ToDoItems.AddAsync(toDoItem);
            await todoContext.SaveChangesAsync();
        }

        public async Task<List<ToDoItemResponceModel>> GetToDoItems()
        {
            var todoitems = await todoContext.ToDoItems.ToListAsync();
            var responce = todoitems.Select(todo => new ToDoItemResponceModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsDone = todo.IsDone,
                Priority = todo.Priority,
                Duedate = todo.Duedate,
                CreatedAt = todo.CreatedAt
            }).ToList();

            return responce;
        }

        public async Task<List<ToDoItemResponceModel>> GetPendingToDoItems()
        {
            var pendingToDos = await todoContext.ToDoItems.Where(todo => todo.IsDone == false).ToListAsync();
            var responce = pendingToDos.Select(todo => new ToDoItemResponceModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsDone = todo.IsDone,
                Priority = todo.Priority,
                Duedate = todo.Duedate,
                CreatedAt = todo.CreatedAt
            }).ToList();
            return responce;
        }
    }
}
