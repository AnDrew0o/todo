using System;
using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoTask> Tasks {get; set; }
    }
}
    