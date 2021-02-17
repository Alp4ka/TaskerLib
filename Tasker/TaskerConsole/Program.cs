using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker;

namespace TaskerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Roman", "Gorkovets");
            User user2 = new User("Bogdan", "Kulikov");
            Project project = new Project("Project1", "The project that helps other to lose their faith in the future ane etc.");
            Task task = new Task("Buy a bread", "Carefully", DateTime.Now, DateTime.Now.AddDays(1));
            Bug bug1 = new Bug("fix", "lol wat shoult i type", responder: user1);
            StoryTask stask = new StoryTask("stask", "fuck");
            EpicTask etask = new EpicTask("Epic task", "ya zaebalsya");
            etask.AddTask(task);
            etask.AddTask(stask);
            task.AddResponder(user1);
            stask.AddResponder(user1);
            stask.AddResponder(user2);
            //Console.WriteLine(String.Join(" ", etask.GetResponders()));
            //etask.AddTask(ta);
            //stask.AddResponder(user1);
            //stask.AddResponder(user2);
            Console.WriteLine(etask);
            etask.Close();
            Console.WriteLine(etask);
            Console.ReadKey();

        }
    }
}
