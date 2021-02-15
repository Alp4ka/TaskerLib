using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker
{
    public class EpicTask:BaseTask
    {
        private List<IAssignable> _subTasks;
        public List<IAssignable> GetTasks()
        {
            return _subTasks;
        }
        //TODO
        public List<User> GetResponders()
        {
            var result = new List<User>();
            foreach(var task in _subTasks)
            {
                if(task is Task)
                {
                    result.Add((task as Task).Responders[0]);
                }
                if (task is StoryTask)
                {
                    result.AddRange((task as StoryTask).Responders);
                }
            }
            return result;
        }
        public void AddTask(IAssignable task)
        {
            if (_subTasks.Contains(task)/* || _subTasks.Select(x=>x.UID).Contains(task.UID)*/)
            {
                throw new ArgumentException($"Task is already in list.");
            }
            if(task is EpicTask)
            {
                throw new ArgumentException($"Unable to add task with type {task.GetType()}");
            }
            _subTasks.Add(task);
        }
        public void RemoveTask(IAssignable task)
        {
            _subTasks.Remove(task);
        }
        public EpicTask(
            string name,
            string description,
            User creator,
            DateTime start = default(DateTime),
            DateTime finish = default(DateTime),
            TaskState state = TaskState.Open,
            List<IAssignable> tasks = null) : base(name, description, creator, start, finish, state)
        {
            _subTasks = new List<IAssignable>();
            if(tasks != null)
            {
                foreach(IAssignable task in tasks)
                {
                    AddTask(task);
                }
            }
        }
    }
}
