﻿using System;

namespace Tasker
{
    public class Bug : BaseTask
    {
        /// <summary>
        /// Add responder.
        /// </summary>
        /// <param name="user"> User. </param>
        new public void AddResponder(User user)
        {
            if (!Responders.Contains(user))
            {
                if (Responders.Count >= 1)
                {
                    throw new Exception("Can't set more than 1 responder for Bug.");
                }
                Responders.Add(user);
            }
        }
        public Bug(
            string name,
            string description,
            TaskState state = TaskState.Open,
            User responder = null) : base(name, description, /*start, finish,*/ state)
        {
            if (responder != null)
            {
                Responders.Add(responder);
            }

        }
        public override string ToString()
        {
            return $"[Bug] '{Name}'  ID: {ID}. " +
                $"{base.ToString()}";
        }
    }
}
