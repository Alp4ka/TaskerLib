using System;
using System.Collections.Generic;

namespace Tasker
{
    public class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        private List<IAssignable> _tasks;
        public List<IAssignable> GetAllTasks()
        {
            return _tasks;
        }
        public void AddTask(IAssignable task)
        {
            if (!_tasks.Contains(task))
            {
                _tasks.Add(task);
            }

        }
        public List<User> GetResponders()
        {
            List<User> result = new List<User>();
            foreach (IAssignable task in _tasks)
            {
                result.AddRange(task.GetResponders());
            }
            return result;
        }
        public void RemoveTask(IAssignable task)
        {
            _tasks.Remove(task);
        }
        public bool SetName(string newName)
        {
            if (newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            Name = newName;
            return true;
        }
        public bool SetDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }
        public Project(string name, string description)
        {
            if (!SetName(name))
            {
                throw new ArgumentException($"Wrong length of name!");
            }
            if (!SetDescription(description))
            {
                throw new ArgumentException($"Wrong length of description!");
            }
        }
        public List<IAssignable> GetTasksByState(BaseTask.TaskState state)
        {
            List<IAssignable> assignables = new List<IAssignable>();
            foreach(IAssignable ia in _tasks)
            {
                if((ia as BaseTask).State == state)
                {
                    assignables.Add(ia);
                }
            }
            return assignables;
        }
        public override string ToString()
        {
            /*return $"Project {Name}:\n" +
                $"Description: {string.Format("{0,25}", Description)}...";*/
            return $"Project {Name}:\n" +
                $"Description: {Description}" +
                $"Responders: {String.Join(" ", GetResponders())}";
        }
    }
}
