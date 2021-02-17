using System;
using System.Collections.Generic;

namespace Tasker
{
    public class BaseTask : IAssignable
    {
        private int _expBuff = 500;
        public int ExpBuff
        {
            get => _expBuff;
            set
            {
                _expBuff = value > 0 ? value : _expBuff;
            }
        }
        public void SetState(TaskState state)
        {
            if (state == State)
            {
                return;
            }
            switch (state)
            {
                case TaskState.Open:
                    State = state;
                    /*foreach(User user in Responders)
                    {
                        RemoveExperience(user);
                    }*/
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
        public void Close()
        {
            SetState(TaskState.Closed);
        }
        public void Process()
        {
            SetState(TaskState.InProgress);
        }
        public void Open()
        {
            SetState(TaskState.Open);
        }
        public List<User> GetResponders()
        {
            return Responders;
        }
        public void EarnExperience(User user)
        {
            user.Experience += _expBuff;
        }
        public void RemoveExperience(User user)
        {
            user.Experience -= _expBuff;
        }
        //private int _uid;
        public enum TaskState
        {
            Open = 0,
            InProgress = 1,
            Closed = 2
        }
        public List<User> Responders { get; set; }
        public void AddResponder(User user)
        {
            if (!Responders.Contains(user))
            {
                Responders.Add(user);
            }
        }
        public void RemoveResponder(User user)
        {
            Responders.Remove(user);
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime DeadlineDate { get; set; }
        //public User Creator { get; set; }
        //public int UID { get => _uid;}
        public TaskState State { get; set; }
        public bool SetName(string newName)
        {
            if (newName.Length < 2 || newName.Length > 30)
            {
                return false;
            }
            Name = newName;
            return true;
        }
        public bool SetDescription(string newDescription)
        {
            Description = newDescription;
            return true;
        }
        /*public bool SetCreator(User newCreator)
        {
            if(newCreator is null)
            {
                return false;
            }
            Creator = newCreator;
            return true;
        }*/
        public BaseTask(string name, string description, DateTime start = default(DateTime), DateTime finish = default(DateTime), TaskState state = TaskState.Open)
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
            StartTime = start;
            DeadlineDate = finish;
            Responders = new List<User>();
        }
        public override string ToString()
        {
            return $"Description: {Description}\n" +
                                $"State: {State}\n" +
                                $"Responders: \n{String.Join(", \n", GetResponders())}\n";
        }
    }
}
