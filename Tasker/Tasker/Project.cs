using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasker
{
    public class Project
    {
        // Project ID.
        public int ID { get; set; }
        // Project Name.
        public string Name { get; set; }
        // Project Description.
        public string Description { get; set; }
        // Get percentage done/all_tasks.
        public double Percentage
        {
            get
            {
                List<IAssignable> temp = GetAllTasks();
                if (temp.Count == 0)
                {
                    return 0;
                }
                Console.WriteLine(String.Join(" ", temp));
                return 100 * (temp.Count(x => (x as BaseTask).State == BaseTask.TaskState.Closed) / ((double)temp.Count));
            }
        }
        private List<IAssignable> _tasks;

        /// <summary>
        /// Add task.
        /// </summary>
        /// <param name="task"> Task. </param>
        public void AddTask(IAssignable task)
        {
            if (!_tasks.Contains(task))
            {
                _tasks.Add(task);
            }

        }

        /// <summary>
        /// Get tasks(1st layer).
        /// </summary>
        /// <param name="state"> Of state. </param>
        /// <returns> List of tasks. </returns>
        public List<IAssignable> GetTasks(BaseTask.TaskState? state = null)
        {
            if (state == null)
            {
                return _tasks;
            }
            List<IAssignable> assignables = new List<IAssignable>();
            foreach (IAssignable ia in _tasks)
            {
                if ((ia as BaseTask).State == state)
                {
                    assignables.Add(ia);
                }
            }
            return assignables;
        }

        /// <summary>
        /// Get all tasks.
        /// </summary>
        /// <returns> List of tasks. </returns>
        public List<IAssignable> GetAllTasks()
        {
            List<IAssignable> result = new List<IAssignable>();
            foreach (IAssignable task in _tasks)
            {
                if (task is EpicTask)
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

        /// <summary>
        /// Get responders list.
        /// </summary>
        /// <returns> List of responders. </returns>
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

        /// <summary>
        /// Remove task.
        /// </summary>
        /// <param name="task"> Remove task. </param>
        public void RemoveTask(IAssignable task)
        {
            _tasks.Remove(task);
        }
        /// <summary>
        /// Set name method.
        /// </summary>
        /// <param name="newName"> String new name. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetName(string newName)
        {
            if (CheckName(newName))
            {
                Name = newName;
                return true;
            }
            return true;
        }
        /// <summary>
        /// Check name.
        /// </summary>
        /// <param name="newName"> string name. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public static bool CheckName(string newName)
        {
            if (newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set description.
        /// </summary>
        /// <param name="newDescription"> String description. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }


        public Project(string name, string description, List<IAssignable> tasks = null)
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

        // Project type.
        public string Type { get => "[Project]"; }
        public override string ToString()
        {
            return $"[Project] '{Name}'. " +
                $"Description: {Description}. " +
                $"Percentage: {Percentage:F2}%";
        }
    }
}
