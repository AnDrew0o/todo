using System.Collections.Generic;
using todo_rest_api.Models;

namespace todo_rest_api
{
    public class TaskListService
    {
        private List<TaskList> taskLists = new List<TaskList> ()
        {
            new TaskList { 
                Id = 1, 
                Title = "First list", 
                Tasks = new List<TodoTask> {
                    new TodoTask() {Id = 1, Title = "Implement read"},
                    new TodoTask() {Id = 2, Title = "Implement create"},
                    new TodoTask() {Id = 3, Title = "Implement delete"}
                }
            },
            new TaskList { 
                Id = 2, 
                Title = "Second list", 
                Tasks = new List<TodoTask> {
                    new TodoTask() {Id = 4, Title = "Refactoring read"},
                    new TodoTask() {Id = 5, Title = "Refactoring create"}
                }
            },
            new TaskList { 
                Id = 3, 
                Title = "Second list", 
                Tasks = new List<TodoTask> ()
            }
        };
        private int lastListId = 3;
        private int lastTaskId = 5;

        public List<TaskList> GetAllLists()
        {
            return taskLists;
        }

        public TaskList GetList(int listId)
        {
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                return list;
            }
            return null;
        }

        public TaskList CreateList(TaskList newList)
        {
            newList.Id = ++lastListId;
            taskLists.Add(newList);
            return newList;
        }

        public TaskList DeleteList(int listId)
        {
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                {
                    taskLists.Remove(list);
                    return list;
                }
            }
            return null;
        }

        // public TaskList PutList(int listId, TaskList newList)
        // {
        //     newList.Id = listId;
        //     foreach (var list in taskLists)
        //     {
        //         if (list.Id == listId)
        //         {
        //             // TaskList changedList = taskLists[taskLists.IndexOf(list)];
        //             // changedList = newList;
        //             // return changedList;
        //             taskLists[taskLists.IndexOf(list)] = newList;
        //             return newList;
        //         }
        //     }
        //     return null;
        // }

        // public TaskList PatchList(int listId, TaskList changedList)
        // {
        //     return null;
        // }
        
        // public List<TodoTask> GetAllTasks()
        // {
        //     return null;
        // }

        public List<TodoTask> GetAllTasks(int listId)
        {
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                {
                    return list.Tasks;
                }
            }
            return null;
        }

        public TodoTask GetTask(int taskId)
        {
            foreach (var list in taskLists)
            {
                foreach (var task in list.Tasks)
                {
                    if (task.Id == taskId)
                    return task;
                }
            }
            return null;
        }

        public TodoTask GetTask(int listId, int taskId)
        {
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                {
                    foreach (var task in list.Tasks)
                    {
                        if (task.Id == taskId)
                        return task;
                    }
                }
            }
            return null;
        }
        
        public TodoTask CreateTask(int listId, TodoTask newTask)
        {
            newTask.Id = ++lastTaskId;
            foreach(var list in taskLists)
            {
                if (list.Id == listId)
                {    
                    list.Tasks.Add(newTask);
                    return newTask;
                }
            }
            return null;
        }

        public TodoTask PutTask(int listId, int taskId, TodoTask changedTask)
        {
            changedTask.Id = taskId;
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                {
                    foreach (var task in list.Tasks)
                    {
                        if (task.Id == taskId)
                        {
                            var index = list.Tasks.IndexOf(task);
                            list.Tasks[index] = changedTask;
                            return list.Tasks[index];
                        }
                    }
                }
            }
            return null;
        }

        public TodoTask PatchTask(int listId, int taskId, TodoTask changedTask)
        {
            changedTask.Id = taskId;
            
            foreach (var list in taskLists)
            {
                if (list.Id == listId)
                {
                    foreach (var task in list.Tasks)
                    {
                        if (task.Id == taskId)
                        {
                            var index = list.Tasks.IndexOf(task);

                            if (changedTask.Title != null)
                                list.Tasks[index].Title = changedTask.Title;

                            if (changedTask.Description != null)
                                list.Tasks[index].Description = changedTask.Description;

                            if (changedTask.DueDate != null)
                                list.Tasks[index].DueDate = changedTask.DueDate;

                            if (changedTask.Done != list.Tasks[index].Done)
                                list.Tasks[index].Done = changedTask.Done;

                            return list.Tasks[index];
                        }
                    }
                }
            }
            return null;
        }
        
        public TodoTask DeleteTask(int listId, int taskId)
        {
            foreach(var list in taskLists)
            {
                if (list.Id == listId)
                {    
                    foreach (var task in list.Tasks)
                    {
                        if (task.Id == taskId)
                        {
                            list.Tasks.Remove(task);
                            return task;
                        }
                    }
                }
            }
            return null;
        }
    }
}