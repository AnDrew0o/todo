using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskListService
    {
        private List<TaskList> taskLists = new List<TaskList>();
        private int lastId = 0;
        public List<TaskList> GetAll()
        {
            return taskLists;
        }

        public TaskList GetById(int id)
        {
            foreach (var item in taskLists)
            {
                if (item.Id == id)
                return item;
            }
            return null;
        }

        public void DeleteById(int id)
        {
            foreach (var item in taskLists)
            {
                if (item.Id == id)
                {
                    taskLists.Remove(item);
                    break;
                }
            }
        }

        public TaskList Create(TaskList item)
        {
            item.Id = ++lastId;
            taskLists.Add(item);

            return item;
        }
    }
}