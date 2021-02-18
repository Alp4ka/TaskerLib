using System;
using System.Collections.Generic;

namespace Tasker
{
    public interface IAssignable
    {
        string Name { get; set; }
        string Description { get; set; }
        //DateTime CreationDate { get; set; }
        //DateTime StartTime { get; set; }
        //DateTime DeadlineDate { get; set; }
        //User Creator { get; set; }
        bool SetDescription(string newDescription);
        List<User> GetResponders();
        //bool SetCreator(User newCreator);
        bool SetName(string newName);
        List<User> Responders { get; set; }
        void AddResponder(User user);
        void RemoveResponder(User user);
    }
}
