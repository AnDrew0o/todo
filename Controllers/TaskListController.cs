using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private TaskListService service;
        public TaskListController(TaskListService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TaskList>> GetTaskLists()
        {
            return service.GetAllLists();
        }

        [HttpGet("{listId}")]
        public ActionResult<TaskList> GetTaskList(int listId)
        {
            TaskList searchedList = service.GetList(listId);
            if (searchedList == null)
                return NotFound($"List with id: {listId} not found");
            return searchedList;
        }

        [HttpPost("")]
        public ActionResult<TaskList> CreateTaskList(TaskList newTaskList)
        {
            TaskList createdList = service.CreateList(newTaskList);
            return Created($"api/lists{createdList.Id}", createdList);
        }

        // [HttpPut("{listId}")]
        // public ActionResult<TaskList> PutTaskList(int listId, TaskList newTaskList)
        // {
        //     return todoItemService.PutList(listId, newTaskList);
        // }

        // [HttpPatch("{listId}")]
        // public ActionResult<TaskList> PatchTaskList(int listId, TaskList newTaskList)
        // {
        //     return todoItemService.PatchList(listId, newTaskList);
        // }

        [HttpDelete("{listId}")]
        public ActionResult<TaskList> DeleteTaskList(int listId)
        {
            TaskList deletedList = service.DeleteList(listId);
            if (deletedList == null)
                return NotFound($"List with id: {listId} not found");
            return deletedList;
        }
    }
}