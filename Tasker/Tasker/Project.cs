using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasker
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Percentage
        {
            get
            {
                List<IAssignable> temp = GetAllTasks();
                Console.WriteLine(String.Join(" ", temp));
                return 100 * (temp.Count(x => (x as BaseTask).State == BaseTask.TaskState.Closed) / ((double)temp.Count));
            }
        }
        private List<IAssignable> _tasks;
        
        public void AddTask(IAssignable task)
        {
            if (!_tasks.Contains(task))
            {
                _tasks.Add(task);
            }

        }
        public List<IAssignable> GetTasks()
        {
            return _tasks;
        }
        public List<IAssignable> GetAllTasks()
        {
            List<IAssignable> result = new List<IAssignable>();
            foreach(IAssignable task in _tasks)
            {
                if(task is EpicTask)
                {
                    result.Add(task);
                    result.AddRange((task as EpicTask).GetTasks());
                }
                else
                {
                    result.Add(task);
                }
            }
            return _tasks;
        }
        public List<User> GetResponders()
        {
            List<User> result = new List<User>();
            foreach (IAssignable task in _tasks)
            {
                result.AddRange(task.GetResponders());
            }
            result = result.Distinct().ToList();
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
        
            
        public Project(string name, string description, List <IAssignable> tasks = null)
        {
            _tasks = new List<IAssignable>();
            if (!SetName(name))
            {
                throw new ArgumentException($"Wrong length of name!");
            }
            if (!SetDescription(description))
            {
                throw new ArgumentException($"Wrong length of description!");
            }
            if (tasks != null)
            {
                foreach (IAssignable task in tasks)
                {
                    AddTask(task);
                }
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
            return $"[Project] '{Name}':\n" +
                $"Description: {Description}\n" +
                $"Responders: {String.Join(", \n", GetResponders())}\n"+
                $"Percentage: {Percentage:F2}%";
        }
    }
}
