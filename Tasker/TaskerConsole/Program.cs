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

            Engine.DrawIntro(new string[] { "Trello Killer", "v 1.0", " ", "Any <Key> to continue..." });
            while (true)
            {
                var menu = Engine.GenerateIDsForMenuItems(new string[] { "my_projects", "users", "exit" }, new string[] { "My Projects", "Users Control", "Exit" });
                switch (Engine.Menu(menu, "Main Menu:"))
                {
                    case "my_projects":
                        ProjectsMenu();
                        break;
                    case "users":
                        UsersControlDialog();
                        break;
                    case "exit":
                        CancelKeyPress(null , null);
                        return;
                    case null:
                        break;
                }
            }
            //_users.Clear();
            //_users.Add(new User("Pasha", "Durov", 100));
            //_users.Add(new User("Roma", "Gorkovets", 10));
            //Task task1 = new Task("task1", "pizdec", state: BaseTask.TaskState.Closed, responder: _users[1]);
            //StoryTask stask1 = new StoryTask("task1", "pizdec", state: BaseTask.TaskState.InProgress, _users);
            //EpicTask etask = new EpicTask("epic", "pizdec123", state: BaseTask.TaskState.InProgress, new List<IAssignable>(new IAssignable[] { task1 }));
            //_tasks.Add(etask);
            //_tasks.Add(task1);
            //_tasks.Add(stask1);

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
        static void ProjectCreationDialog()
        {
            string name, description;
            name = ProjectSetNameDialog();
            description = ProjectSetDescriptionDialog();
            Project project = new Project(name, description);
            Projects.Add(project);
            DBManager.SaveChanges();
        }
        static string ProjectSetNameDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type project's Name:", ref checker);
                if (result == null)
                {
                    message = "[Not able to exit]";
                    continue;
                }
                else if (Project.CheckName(result))
                {
                    return result;
                }
                else
                {
                    message = "[Name's lenght should be more than 1 symbol and less than 31]";
                    continue;
                }
            }
        }
        static string ProjectSetDescriptionDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type project's Description:", ref checker);
                if (result == null)
                {
                    message = "[Not able to exit]";
                    continue;
                }
                else
                {
                    return result;
                }
            }
        }
        static void UsersControlDialog()
        {
            while (true)
            {
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.Add("create_new");
                choice.Add("<New User>");
                ids.AddRange(Users.Select(x => x.ID.ToString()).ToArray());
                choice.AddRange(Users.Select(x => $"{x.Fullname} Rank: {x.Rank} with {x.Experience} exp.").ToArray());
                Console.WriteLine(String.Join(" ", ids));
                var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: "Users Control");
                switch (result)
                {
                    case "create_new":
                        UserCreation();
                        break;
                    case null:
                        return;
                    default:
                        return;
                }
            }
        }
        static void UserCreation()
        {
            string name, surname;
            name = SetUserNameDialog();
            surname = SetUserSurnameDialog();
            User user = new User(name, surname);
            Users.Add(user);
            DBManager.SaveChanges();

        }
        static string SetUserNameDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type user's Name:", ref checker);
                if (result == null)
                {
                    message = "[Not able to exit]";
                    continue;
                }
                else if (User.CheckName(result))
                {
                    return result;
                }
                else
                {
                    message = "[Name's lenght should be more than 1 symbol and less than 31]";
                    continue;
                }
            }
        }
        static string SetUserSurnameDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type user's Surname:", ref checker);
                if (result == null)
                {
                    message = "[Not able to exit]";
                    continue;
                }
                else if (User.CheckSurname(result))
                {
                    return result;
                }
                else
                {
                    message = "[Surname's lenght should be more than 1 symbol and less than 41]";
                    continue;
                }
            }
        }
        static void ProjectsMenu()
        {
            while (true)
            {
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.Add("create_new");
                choice.Add("<Create New>");
                ids.AddRange(Projects.Select(x => x.ID.ToString()).ToArray());
                choice.AddRange(Projects.Select(x => x.Name + " ID:" + x.ID.ToString()).ToArray());
                var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string dialogResult = Engine.Menu(menu, "Projects:");
                switch (dialogResult)
                {
                    case "create_new":
                        ProjectCreationDialog();
                        break;
                    case null:
                        return;
                    default:
                        var searchResult = Projects.FindAll(x => x.ID == int.Parse(dialogResult));
                        if (searchResult.Count > 0)
                        {
                            ProjectWindow(searchResult[0]);
                        }
                        break;
                }
            }
        }
       static void ProjectWindow(Project project)
       {
            while (true)
            {
                var tasks = project.GetTasks(BaseTask.TaskState.Open);
                tasks.AddRange(project.GetTasks(BaseTask.TaskState.InProgress));
                tasks.AddRange(project.GetTasks(BaseTask.TaskState.Closed));
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.Add("create_new");
                ids.Add("delete_current");
                choice.Add("<New Task>");
                choice.Add("<Delete>");
                ids.AddRange(tasks.Select(x => x.ToString()).ToArray());
                choice.AddRange(tasks.Select(x => x.Name + $" ID: {x.ID}. Status: {(x as BaseTask).State}").ToArray());
                var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: project.ToString());
                switch (result)
                {
                    case "create_new":
                        TaskCreationDialog(project);
                        break;
                    case "delete_current":
                        foreach(IAssignable task in project.GetAllTasks())
                        {
                            Tasks.Remove(task);
                        }
                        Projects.Remove(project);
                        DBManager.ReloadDB();
                        return;
                    case null:
                        return;
                    default:
                        var searchResult = project.GetTasks().FindAll(x => x.ToString() == result);
                        if (searchResult.Count > 0)
                        {
                            TaskWindow(searchResult[0]);
                        }
                        break;
                }
            }
       }
        static void TaskCreationDialog(Project parent)
        {

        }
        static void TaskCreationDialog(EpicTask parent)
        {

        }
        static void TaskWindow(IAssignable task)
        {
            while (true)
            {
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                Dictionary<string, string> menu;
                if (task is EpicTask)
                {
                    menu = Engine.GenerateIDsForMenuItems(new string[] { "change_name", "change_description", "show_tasks" }, new string[] { "Change Name", "Change Description", "Tasks" });
                }
                else
                {
                    menu = Engine.GenerateIDsForMenuItems(new string[] { "change_name", "change_description", "show_responders" }, new string[] { "Change Name", "Change Description", "Responders" });
                }

                string result = Engine.Menu(menu, title: task.ToString());
                switch (result)
                {
                    case "change_name":
                        Engine.DrawWindow(new string[] { "change_name" });
                        break;
                    case "change_description":
                        Engine.DrawWindow(new string[] { "change_description" });
                        break;
                    case "show_tasks":
                        Engine.DrawWindow(new string[] { "show_tasks" });
                        break;
                    case "show_responders":
                        Engine.DrawWindow(new string[] { "show_responders" });
                        break;
                    case null:
                        return;
                }
            }
        }
    }
}
