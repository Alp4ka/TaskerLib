using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasker
{
    public class EpicTask:BaseTask
    {
        private List<IAssignable> _subTasks;
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
        //TODO
        new public void AddResponder(User user)
        {
        }
        new public void RemoveResponder(User user)
        {
        }
        new public List<User> GetResponders()
        {
            var result = new List<User>();
            foreach(var task in _subTasks)
            {
                result.AddRange(task.GetResponders());
            }
            result = result.Distinct().ToList();
            return result;
        }
        public void AddTask(IAssignable task)
        {
            if (_subTasks.Contains(task)/* || _subTasks.Select(x=>x.UID).Contains(task.UID)*/)
            {
                throw new ArgumentException($"Task is already in list.");
            }
            if(task is EpicTask || task is Bug)
            {
                throw new ArgumentException($"Unable to add task with type {task.GetType()}");
            }
            _subTasks.Add(task);
        }
        public void AddTasks(List<IAssignable> tasks)
        {
            foreach(IAssignable task in tasks)
            {
                AddTask(task);
            }
        }
        public void RemoveTask(IAssignable task)
        {
            _subTasks.Remove(task);
        }
        public EpicTask(
            string name,
            string description,
            /*DateTime start = default(DateTime),
            DateTime finish = default(DateTime),*/
            TaskState state = TaskState.Open,
            List<IAssignable> tasks = null) : base(name, description, /*start, finish,*/ state)
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
        public override string ToString()
        {
            return $"[EpicTask] '{Name}'  ID: {ID}. " +
                //$"SubTasks: {String.Join(", ", GetTasks().Select(x => "[" + x.Name + "]"))}\n" +
                $"Description: {Description}. " +
                $"State: {State}. "+
                $"Creation: {CreationDate}";
                //$"Responders: \n{String.Join(", \n", GetResponders())}\n";
        }
    }
}
