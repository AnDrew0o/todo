using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        static private List<TodoItem> todoItems = new List<TodoItem> {
                new TodoItem() {Id = 1, Title = "Implement read"},
                new TodoItem() {Id = 2, Title = "Implement create"}
            };
        static private int lastId = 2;

        public TodoItemController()
        {
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItemById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            todoItem.Id = ++lastId;
            todoItems.Add(todoItem);

            return Created($"api/todoitem/{todoItem.Id}", todoItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItemById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}