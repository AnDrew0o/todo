using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        public TaskListController()
        {
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<TaskList>>> GetTaskLists()
        {
            // TODO: Your code here
            await Task.Yield();

            return new List<TaskList> { };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskListById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public async Task<ActionResult<TaskList>> PostTaskList(TaskList model)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskList(int id, TaskList model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskList>> DeleteTaskListById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}