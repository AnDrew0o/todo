using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoItem> Tasks {get; set; }
    }
}
    