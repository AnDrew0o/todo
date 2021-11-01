using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api;

namespace todo_rest_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService todoItemService;

        public TodoItemController(TodoItemService service)
        {
            this.todoItemService = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItemService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItemById(int id)
        {
            if (todoItemService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                return todoItemService.GetById(id);
            }
        }

        [HttpPost("")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            TodoItem createdItem = todoItemService.Create(todoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

        [HttpPut("{id}")]
        public ActionResult<TodoItem> PutTodoItem(int id, TodoItem todoItem)
        {
            todoItem = todoItemService.PutItem(id, todoItem);
            return todoItem;
        }

        //[HttpPatch("{id}")]

        [HttpDelete("{id}")]
        public ActionResult<TodoItem> DeleteTodoItemById(int id)
        {
            todoItemService.DeleteById(id);
            return null;
        }
    }
}