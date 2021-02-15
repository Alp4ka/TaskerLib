using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            User creator,
            DateTime start = default(DateTime),
            DateTime finish = default(DateTime),
            TaskState state = TaskState.Open,
            User responder = null) :base(name, description, creator, start, finish, state)
        {
            if(responder != null)
            {
                Responders.Add(responder);
            }
            
        }
    }
}
