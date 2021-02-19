using System;

namespace Tasker
{
    public class Task : BaseTask
    {
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
            /*DateTime start = default(DateTime),
            DateTime finish = default(DateTime),*/
            TaskState state = TaskState.Open,
            User responder = null) :base(name, description, /*start, finish,*/ state)
        {
            if(responder != null)
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
