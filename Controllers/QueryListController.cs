using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class QueryListController : ControllerBase
    {
        private TaskListService service;
        public QueryListController(TaskListService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<TaskList> GetTaskList(int listId)
        {
            TaskList searchedList = service.GetList(listId);
            if (searchedList == null)
                return NotFound($"List with id: {listId} not found");
            return searchedList;
        }

        [HttpPost]
        public ActionResult<TaskList> CreateTaskList(TaskList newTaskList)
        {
            TaskList createdList = service.CreateList(newTaskList);
            return Created($"api/lists{createdList.Id}", createdList);
        }

        [HttpDelete]
        public ActionResult<TaskList> DeleteTaskList(int listId)
        {
            TaskList deletedList = service.DeleteList(listId);
            if (deletedList == null)
                return NotFound($"List with id: {listId} not found");
            return deletedList;
        }
    }
}