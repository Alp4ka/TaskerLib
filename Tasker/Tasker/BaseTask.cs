using System;
using System.Collections.Generic;

namespace Tasker
{
    public class BaseTask : IAssignable
    {
        // Base task ID.
        public int ID { get; set; }

        private int _expBuff = 500;

        // Experience buff.
        public int ExpBuff
        {
            get => _expBuff;
            set
            {
                _expBuff = value > 0 ? value : _expBuff;
            }
        }

        /// <summary>
        /// Set task state.
        /// </summary>
        /// <param name="state"> State. </param>
        public void SetState(TaskState state)
        {
            if (state == State)
            {
                return;
            }
            switch (state)
            {
                case TaskState.Open:
                    if(State == TaskState.Closed)
                    {
                        foreach (User user in Responders)
                        {
                            RemoveExperience(user);
                        }
                    }
                    State = state;
                    break;
                case TaskState.InProgress:
                    State = state;
                    break;
                case TaskState.Closed:
                    State = state;
                    List<User> responders = this.GetResponders();
                    if(this is EpicTask)
                    {
                        responders = (this as EpicTask).GetResponders();
                    }
                    foreach (User user in responders)
                    {
                        EarnExperience(user);
                    }
                    break;
            }
        }

        /// <summary>
        /// Close task.
        /// </summary>
        public void Close()
        {
            SetState(TaskState.Closed);
        }

        /// <summary>
        /// In process task.
        /// </summary>
        public void Process()
        {
            SetState(TaskState.InProgress);
        }

        /// <summary>
        /// Open task.
        /// </summary>
        public void Open()
        {
            SetState(TaskState.Open);
        }

        /// <summary>
        /// Get responders.
        /// </summary>
        /// <returns></returns>
        public List<User> GetResponders()
        {
            return Responders;
        }

        /// <summary>
        /// Earn experience.
        /// </summary>
        /// <param name="user"></param>
        private void EarnExperience(User user)
        {
            user.Experience += _expBuff;
        }

        /// <summary>
        /// Remove experience.
        /// </summary>
        /// <param name="user"></param>
        private void RemoveExperience(User user)
        {
            user.Experience -= _expBuff;
        }

        /// <summary>
        /// State enum.
        /// </summary>
        public enum TaskState
        {
            Open = 0,
            InProgress = 1,
            Closed = 2
        }

        /// <summary>
        /// List of responders.
        /// </summary>
        public List<User> Responders { get; set; }

        /// <summary>
        /// Add responder.
        /// </summary>
        /// <param name="user"> Responder. </param>
        public void AddResponder(User user)
        {
            if (!Responders.Contains(user))
            {
                Responders.Add(user);
            }
        }
        /// <summary>
        /// Remove responders.
        /// </summary>
        /// <param name="user"> Responder. </param>
        public void RemoveResponder(User user)
        {
            Responders.Remove(user);
        }

        // String name.
        public string Name { get; set; }
        // String description.
        public string Description { get; set; }
        // Creation date property.
        public DateTime CreationDate { get; set; }
        // Task state.
        public TaskState State { get; set; }
        /// <summary>
        /// Set name.
        /// </summary>
        /// <param name="newName"></param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetName(string newName)
        {
            if (newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            Name = newName;
            return true;
        }
        // Get string of type.
        public string Type
        {
            get
            {
                if(this is EpicTask)
                {
                    return "[EpicTask]";
                }
                else if(this is Bug)
                {
                    return "[Bug]";
                }
                else if (this is Task)
                {
                    return "[Task]";
                }
                else if (this is StoryTask)
                {
                    return "[StoryTask]";
                }
                else
                {
                    return "[BaseTask]";
                }

            }
        }
        /// <summary>
        /// Check name.
        /// </summary>
        /// <param name="name"> String name. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public static bool CheckName(string name)
        {
            if (name.Length < 2 || name.Length > 30)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Set description.
        /// </summary>
        /// <param name="newDescription"> String description. </param>
        /// <returns> true if correct, false otherwise. </returns>
        public bool SetDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }
        public BaseTask(string name, string description, /*DateTime start = default(DateTime), DateTime finish = default(DateTime),*/ TaskState state = TaskState.Open)
        {
            if (!SetName(name))
            {
                throw new ArgumentException($"Wrong length of name!");
            }
            if (!SetDescription(description))
            {
                throw new ArgumentException($"Wrong length of description!");
            }
            State = state;
            CreationDate = DateTime.Now;
            Responders = new List<User>();
        }
        public override string ToString()
        {
            return $"Description: {Description}. " +
                                $"State: {State}. "+
                                $"Creation: {CreationDate}";
        }
    }
}
