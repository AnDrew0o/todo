using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{

    [Route("api/lists/{listId}/tasks")]
    [ApiController]
    public class TodoTaskController : ControllerBase
    {
        private TaskListService service;

        public TodoTaskController(TaskListService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoTask>> GetTodoTasks(int listId)
        {
            return service.GetAllTasks(listId);
        }

        [HttpGet("{taskId}")]
        public ActionResult<TodoTask> GetTodoTask(int listId, int taskId)
        {
            return service.GetTask(listId, taskId);
        }

        [HttpPost("")]
        public ActionResult<TodoTask> CreateTodoTask(int listId, TodoTask newTask)
        {
            return service.CreateTask(listId, newTask);
        }

        [HttpPut("{taskId}")]
        public ActionResult<TodoTask> PutTodoTask(int listId, int taskId, TodoTask newTask)
        {
            return service.PutTask(listId, taskId, newTask);
        }

        [HttpPatch("{taskId}")]
        public ActionResult<TodoTask> PatchTodoTask(int listId, int taskId, TodoTask newTask)
        {
            return service.PatchTask(listId, taskId, newTask);
        }

        [HttpDelete("{taskId}")]
        public ActionResult<TodoTask> DeleteTodoTask(int listId, int taskId)
        {
            return service.DeleteTask(listId, taskId);
        }
    }
}