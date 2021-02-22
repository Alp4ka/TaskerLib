using System;
using System.Collections.Generic;

namespace Tasker
{
    public interface IAssignable
    {
        string Name { get; set; }
        string Description { get; set; }
        int ID { get; set; }
        string Type { get; }
        bool SetDescription(string newDescription);
        List<User> GetResponders();
        bool SetName(string newName);
        List<User> Responders { get; set; }
        void AddResponder(User user);
        void RemoveResponder(User user);
    }
}
