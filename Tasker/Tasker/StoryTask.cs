using System;
using System.Collections.Generic;

namespace Tasker
{
    class StoryTask:BaseTask
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
        public override string ToString()
        {
            return $"StoryTask {Name}\n" +
                $"Description: {Description}\n" +
                $"Responders: {String.Join(" ", GetResponders())}";
        }
    }
}
