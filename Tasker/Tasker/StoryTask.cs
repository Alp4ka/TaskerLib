using System;
using System.Collections.Generic;

namespace Tasker
{
    public class StoryTask:BaseTask
    {
        public StoryTask(
            string name,
            string description,
            TaskState state = TaskState.Open,
            List<User> responders = null) : base(name, description, /*start, finish,*/ state)
        {
            if(responders != null)
            {
                foreach(User user in responders)
                {
                    AddResponder(user);
                }
            }
        }

        /// <summary>
        /// Add responders method.
        /// </summary>
        /// <param name="users"> Responders list. </param>
        public void AddResponders(List<User> users)
        {
            foreach(User user in users)
            {
                AddResponder(user);
            }
        }
        public override string ToString()
        {
            return $"[StoryTask] '{Name}'  ID: {ID}. " + 
                $"{base.ToString()}";
        }
    }
}
