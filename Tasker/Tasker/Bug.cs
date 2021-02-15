using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasker
{
    public class Bug : BaseTask
    {
        public Bug(
            string name,
            string description,
            User creator,
            DateTime start = default(DateTime),
            DateTime finish = default(DateTime),
            TaskState state = TaskState.Open,
            User responder = null) : base(name, description, creator, start, finish, state)
        {
            if (responder != null)
            {
                Responders.Add(responder);
            }

        }
    }
}
