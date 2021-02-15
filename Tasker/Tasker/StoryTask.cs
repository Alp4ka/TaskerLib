using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker
{
    class StoryTask:BaseTask
    {
        public StoryTask(
            string name,
            string description,
            User creator,
            DateTime start = default(DateTime),
            DateTime finish = default(DateTime),
            TaskState state = TaskState.Open,
            List<IAssignable> tasks = null,
            List<User> responders = null) : base(name, description, creator, start, finish, state)
        {
            if(responders != null)
            {
                foreach(User user in responders)
                {
                    AddResponder(user);
                }
            }
        }
    }
}
