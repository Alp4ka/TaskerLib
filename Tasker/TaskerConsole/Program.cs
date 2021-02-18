using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker;
using ConsoleEngine;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;

namespace TaskerConsole
{
    class Program
    {
        public static List<User> Users = DBManager._users;
        public static List<Project> Projects = DBManager._projects;
        public static List<IAssignable> Tasks = DBManager._tasks;

        static void Main(string[] args)
        {
            Console.CancelKeyPress += CancelKeyPress;
            DBManager.SetPath(@".\db.db");
            DBManager.InitializeDatabase();
            DBManager.ReadDataBase();


            //Console.WriteLine(String.Join("\n", Users));
            Project proj = new Project("project1", "project12334234234234", Tasks);
            Projects.Add(proj);
            Console.WriteLine(proj);
            //_users.Clear();
            //_users.Add(new User("Pasha", "Durov", 100));
            //_users.Add(new User("Roma", "Gorkovets", 10));
            //Task task1 = new Task("task1", "pizdec", state: BaseTask.TaskState.Closed, responder: _users[1]);
            //StoryTask stask1 = new StoryTask("task1", "pizdec", state: BaseTask.TaskState.InProgress, _users);
            //EpicTask etask = new EpicTask("epic", "pizdec123", state: BaseTask.TaskState.InProgress, new List<IAssignable>(new IAssignable[] { task1 }));
            //_tasks.Add(etask);
            //_tasks.Add(task1);
            //_tasks.Add(stask1);
           
            Console.ReadKey();
            #region
            /*string[] array = new string[] {""};
            Array.Resize(ref array, 100);
            array = array.Select((x, i) => i.ToString()).ToArray();
            var menu = Engine.GenerateIDsForMenuItems(array, array);
            switch (Engine.ScrollableMenu(menu, 10,  "Ya ebal tvou telku u", additionalInfo: new string[] {"1", "2", "3"}))
            {
                case "start":
                    Engine.DrawWindow(new string[] { "grizha1" }, title: "PIZDEC1!");
                    break;
                case "instruction":
                    Engine.DrawWindow(new string[] { "grizha2" }, title: "PIZDEC2!");
                    break;
                case "exit":
                    Engine.DrawWindow(new string[] { "NATASHA" }, title: "LOH");
                    break;
                case null:
                    Engine.DrawWindow(new string[] { "null" }, title: "NULL");
                    break;
            }
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
            */
            #endregion
        }
    
        static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            DBManager.Connection.Close();
            DBManager.SaveChanges();
            Environment.Exit(1);
        }
       
    }
}
