using System;
using System.Collections.Generic;

namespace Tasker
{
    public class StoryTask:BaseTask
    {
        public StoryTask(
            string name,
            string description,
            DateTime start = default(DateTime),
            DateTime finish = default(DateTime),
            TaskState state = TaskState.Open,
            List<IAssignable> tasks = null,
            List<User> responders = null) : base(name, description, start, finish, state)
        {
            if(responders != null)
            {
                foreach(User user in responders)
                {
                    AddResponder(user);
                }
            }
        }
        public void AddResponders(List<User> users)
        {
            foreach(User user in users)
            {
                AddResponder(user);
            }
        }
        public override string ToString()
        {
            return $"[StoryTask] '{Name}'\n" + 
                $"{base.ToString()}";
        }
    }
}
