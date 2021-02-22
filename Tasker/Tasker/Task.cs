using System;

namespace Tasker
{
    public class Task : BaseTask
    {
        /// <summary>
        /// Add responder to task.
        /// </summary>
        /// <param name="user"></param>
        new public void AddResponder(User user)
        {
            if (!Responders.Contains(user))
            {
                if (Responders.Count >= 1)
                {
                    throw new Exception("Can't set more than 1 responder for Task.");
                }
                Responders.Add(user);
            }
        }
        public Task(
            string name,
            string description,
            TaskState state = TaskState.Open,
            User responder = null) : base(name, description, state)
        {
            if (responder != null)
            {
                Responders.Add(responder);
            }

        }
        public override string ToString()
        {
            return $"[Task] '{Name}'  ID: {ID}. " +
                $"{base.ToString()}";
        }
    }
}
