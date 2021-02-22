using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasker
{
    public class EpicTask : BaseTask
    {
        private List<IAssignable> _subTasks;

        /// <summary>
        /// Get subtasks.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<IAssignable> GetTasks(BaseTask.TaskState? state = null)
        {
            if (state == null)
            {
                return _subTasks;
            }
            List<IAssignable> assignables = new List<IAssignable>();
            foreach (IAssignable ia in _subTasks)
            {
                if ((ia as BaseTask).State == state)
                {
                    assignables.Add(ia);
                }
            }
            return assignables;
        }

        /// <summary>
        /// Overrididng addresponder method.
        /// </summary>
        /// <param name="user"></param>
        new public void AddResponder(User user)
        {
        }

        /// <summary>
        /// Overriding addresponder method.
        /// </summary>
        /// <param name="user"></param>
        new public void RemoveResponder(User user)
        {
        }

        /// <summary>
        /// Get responders.
        /// </summary>
        /// <returns></returns>
        new public List<User> GetResponders()
        {
            var result = new List<User>();
            foreach (var task in _subTasks)
            {
                result.AddRange(task.GetResponders());
            }
            result = result.Distinct().ToList();
            return result;
        }

        /// <summary>
        /// Add task method.
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(IAssignable task)
        {
            if (_subTasks.Contains(task))
            {
                throw new ArgumentException($"Task is already in list.");
            }
            if (task is EpicTask || task is Bug)
            {
                throw new ArgumentException($"Unable to add task with type {task.GetType()}");
            }
            _subTasks.Add(task);
        }

        /// <summary>
        /// Add tasks.
        /// </summary>
        /// <param name="tasks"> List of tasks. </param>
        public void AddTasks(List<IAssignable> tasks)
        {
            foreach (IAssignable task in tasks)
            {
                AddTask(task);
            }
        }
        /// <summary>
        /// Remove task.
        /// </summary>
        /// <param name="task"></param>
        public void RemoveTask(IAssignable task)
        {
            _subTasks.Remove(task);
        }
        public EpicTask(
            string name,
            string description,
            TaskState state = TaskState.Open,
            List<IAssignable> tasks = null) : base(name, description, /*start, finish,*/ state)
        {
            _subTasks = new List<IAssignable>();
            if (tasks != null)
            {
                foreach (IAssignable task in tasks)
                {
                    AddTask(task);
                }
            }
        }
        public override string ToString()
        {
            return $"[EpicTask] '{Name}'  ID: {ID}. " +
                $"Description: {Description}. " +
                $"State: {State}. " +
                $"Creation: {CreationDate}";
        }
    }
}
