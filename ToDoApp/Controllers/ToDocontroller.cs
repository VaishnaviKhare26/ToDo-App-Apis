using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Model;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(DBHelper dbHelper) : ControllerBase
    {
        private readonly DBHelper _dbHelper = dbHelper;
        /// <summary>
        /// Get All ToDoItems
        /// </summary>
        /// <returns></returns>
        
        [HttpGet("GetToDoItems")]
        [Authorize]
        public async Task<IActionResult> GetToDoItems()
        {
            try
            {
                var todoItems =await _dbHelper.GetToDoItems();
                return Ok(todoItems);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        [HttpGet("GetpendingToDoItems")]
        public async Task<IActionResult> GetpendingToDoItems()
        {
            try
            {
                var todoItems = await _dbHelper.GetPendingToDoItems();
                return Ok(todoItems);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        /// <summary>
        /// Add Items to ToDo List
        /// </summary>
        /// <param name="toDoItemRequestModel"></param>
        /// <returns></returns>
        [HttpPost("AddToDoItem")]
        
        public async Task<IActionResult> AddToDoItem([FromBody]ToDoItemRequestModel toDoItemRequestModel)
        {
            if(toDoItemRequestModel == null)
            {
                return BadRequest();
            }
            try
            {
                await _dbHelper.AddToDoItem(toDoItemRequestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
