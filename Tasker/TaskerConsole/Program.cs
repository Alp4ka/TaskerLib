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

            Engine.DrawIntro(new string[] { "Trello Killer", "v 1.0", " ", "To move back use <ESC>","To use autosave, use button <Exit> instead of standart button.","Any <Key> to continue..." });
            while (true)
            {
                var menu = Engine.GenerateIDsForMenuItems(new string[] { "my_projects", "users", "exit" }, new string[] { "My Projects", "Users", "Exit" });
                switch (Engine.Menu(menu, "Main Menu:"))
                {
                    case "my_projects":
                        ProjectsMenu();
                        break;
                    case "users":
                        UsersControlDialog();
                        break;
                    case "exit":
                        CancelKeyPress(null, null);
                        return;
                    case null:
                        break;
                }
            }
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
                choice.AddRange(Users.Select(x => $"{x.Type} {x.Fullname} Rank: {x.Rank} with {x.Experience} exp.").ToArray());
                var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: "Users");
                switch (result)
                {
                    case "create_new":
                        UserCreation();
                        break;
                    case null:
                        return;
                    default:
                        UserPageDialog(Users.Where(x => x.ID == int.Parse(result)).First());
                        break;
                }
            }
        }
        static void UserPageDialog(User user)
        {
            List<string> ids = new List<string>();
            List<string> choice = new List<string>();
            ids.Add("delete_current");
            choice.Add("<Delete>");
            var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
            string result = Engine.Menu(menu, title: $"Users {user}");
            switch (result)
            {
                case "delete_current":
                    foreach (IAssignable task in Tasks)
                    {
                        task.RemoveResponder(user);
                    }
                    Users.Remove(user);
                    DBManager.SaveChanges();
                    return;
                case null:
                    return;
                default:
                    return;
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
                choice.AddRange(Projects.Select(x => x.Type + " " + x.Name + " ID:" + x.ID.ToString()).ToArray());
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
                choice.Add("<New Task>");
                ids.AddRange(tasks.Select(x => x.ToString()).ToArray());
                choice.AddRange(tasks.Select(x => x.Type+ " " + x.Name + $" ID: {x.ID}. Status: {(x as BaseTask).State}").ToArray());
                ids.Add("delete_current");
                choice.Add("<Delete>");
                var menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: project.ToString());
                switch (result)
                {
                    case "create_new":
                        CreateTask(project);
                        break;
                    case "delete_current":
                        foreach (IAssignable task in project.GetAllTasks())
                        {
                            Tasks.Remove(task);
                        }
                        Projects.Remove(project);
                        DBManager.SaveChanges();
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
        static void CreateTask(Project parent)
        {
            string name, description;
            //BaseTask.TaskState state;
            name = SetTaskNameDialog();
            description = SetTaskDescriptionDialog();
            IAssignable task = SetTypeDialog(name, description);
            Tasks.Add(task);
            parent.AddTask(task);
            DBManager.SaveChanges();
            //state = SetStateDialog(task);
        }
        static BaseTask.TaskState SetStateDialog(IAssignable task)
        {
            while (true)
            {
                var menu = Engine.GenerateIDsForMenuItems(new string[] { "open", "in_progress", "closed"}, new string[] { "Open", "In Progress", "Closed"});
                string result = Engine.Menu(menu, title: $"{task.Name} Status Change");
                switch (result)
                {
                    case "open":
                        (task as BaseTask).SetState(BaseTask.TaskState.Open);
                        return (task as BaseTask).State;
                    case "in_progress":
                        (task as BaseTask).SetState(BaseTask.TaskState.InProgress);
                        return (task as BaseTask).State;
                    case null:
                        break;
                    case "closed":
                        (task as BaseTask).SetState(BaseTask.TaskState.Closed);
                        return (task as BaseTask).State;
                    default:
                        break;
                }
            }
        }
        static IAssignable SetTypeDialog(string name, string description, bool isPorject=true)
        {
            while (true)
            {
                if (isPorject)
                {
                    var menu = Engine.GenerateIDsForMenuItems(new string[] { "task", "bug", "epic", "story" }, new string[] { "Task", "Bug", "Epic Task", "Story Task" });
                    string result = Engine.Menu(menu, title: $"Type selector");
                    switch (result)
                    {
                        case "task":
                            return new Task(name, description);
                        case "bug":
                            return new Bug(name, description);
                        case null:
                            break;
                        case "epic":
                            return new EpicTask(name, description);
                        case "story":
                            return new StoryTask(name, description);
                        default:
                            break;
                    }
                }
                else
                {
                    var menu = Engine.GenerateIDsForMenuItems(new string[] { "task", "story" }, new string[] { "Task", "Story Task" });
                    string result = Engine.Menu(menu, title: $"Type selector");
                    switch (result)
                    {
                        case "task":
                            return new Task(name, description);
                        case null:
                            break;
                        case "story":
                            return new StoryTask(name, description);
                        default:
                            break;
                    }
                }
            }
        }
        static string SetTaskNameDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type task's Name:", ref checker);
                if (result == null)
                {
                    message = "[Not able to exit]";
                    continue;
                }
                else if (BaseTask.CheckName(result))
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
        static string SetTaskDescriptionDialog()
        {
            string message = "";
            while (true)
            {
                bool checker = false;
                string result = Engine.GetStringWithContext($"{message} Type task's Description:", ref checker);
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
        static void CreateTask(EpicTask parent)
        {
            string name, description;
            //BaseTask.TaskState state;
            name = SetTaskNameDialog();
            description = SetTaskDescriptionDialog();
            IAssignable task = SetTypeDialog(name, description, false);
            Tasks.Add(task);
            parent.AddTask(task);
            DBManager.SaveChanges();
        }
        static void EpicTaskTasksWindow(EpicTask epic)
        {
            while (true)
            {
                var tasks = epic.GetTasks(BaseTask.TaskState.Open);
                tasks.AddRange(epic.GetTasks(BaseTask.TaskState.InProgress));
                tasks.AddRange(epic.GetTasks(BaseTask.TaskState.Closed));
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.Add("create_new");
                choice.Add("<New Task>");
                ids.AddRange(tasks.Select(x => x.ToString()).ToArray());
                choice.AddRange(tasks.Select(x => x.Type + " " + x.Name + $" ID: {x.ID}. Status: {(x as BaseTask).State}").ToArray());
                Dictionary<string, string> menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: "Subtasks Menu:");
                switch (result)
                {
                    case "create_new":
                        CreateTask(epic);
                        break;
                    default:
                        var searchResult = epic.GetTasks().FindAll(x => x.ToString() == result);
                        if (searchResult.Count > 0)
                        {
                            TaskWindow(searchResult[0]);
                        }
                        break;
                    case null:
                        return;
                }
            }
        }
        static void ResponderWindow(IAssignable task, User responder)
        {
            while (true)
            {
                Dictionary<string, string> menu = Engine.GenerateIDsForMenuItems(new string[] { "remove"}, new string[] { "<Remove>"});
                string result = Engine.ScrollableMenu(menu, 10, title: $"Responder {responder} in {task.Type} {task.Name}:");
                switch (result)
                {
                    case "remove":
                        task.RemoveResponder(responder);
                        DBManager.SaveChanges();
                        return;
                    default:
                        break;
                    case null:
                        return;
                }
            }
        }
        static void AddResponderWindow(IAssignable task)
        {
            while (true)
            {
                var res = Users.Except(task.GetResponders()).ToList();
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.AddRange(res.Select(x => x.ID.ToString()).ToArray());
                choice.AddRange(res.Select(x => $"{x.Type} {x.Fullname} Rank: {x.Rank} with {x.Experience} exp.").ToArray());
                Dictionary<string, string> menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: $"Add Responder to {task.Type} {task.Name}:");
                switch (result)
                {
                    default:
                        var searchResult = res.FindAll(x => x.ID == int.Parse(result));
                        if (searchResult.Count > 0)
                        {
                            task.AddResponder(searchResult[0]);
                            DBManager.SaveChanges();
                        }
                        break;
                    case null:
                        return;
                }
            }
        }
        static void ShowRespondersWindow(IAssignable task)
        {
            while (true)
            {
                var res = task.GetResponders();
                List<string> ids = new List<string>();
                List<string> choice = new List<string>();
                ids.Add("add_new");
                choice.Add("<Add Responder>");
                ids.AddRange(res.Select(x => x.ID.ToString()).ToArray());
                choice.AddRange(res.Select(x => $"{x.Type} {x.Fullname} Rank: {x.Rank} with {x.Experience} exp.").ToArray());
                Dictionary<string, string> menu = Engine.GenerateIDsForMenuItems(ids.ToArray(), choice.ToArray());
                string result = Engine.ScrollableMenu(menu, 10, title: $"{task.Type} {task.Name} Responders:");
                switch (result)
                {
                    case "add_new":
                        AddResponderWindow(task);
                        break;
                    default:
                        var searchResult = res.FindAll(x => x.ID == int.Parse(result));
                        if (searchResult.Count > 0)
                        {
                            ResponderWindow(task, searchResult[0]);
                        }
                        break;
                    case null:
                        return;
                }
            }
        }
        static void TaskWindow(IAssignable task)
        {
            while (true)
            {
                Dictionary<string, string> menu;
                if (task is EpicTask)
                {
                    menu = Engine.GenerateIDsForMenuItems(new string[] {"show_tasks", "state", "delete" }, new string[] {"Tasks", "Set State","<Delete>" });
                }
                else
                {
                    menu = Engine.GenerateIDsForMenuItems(new string[] { "show_responders", "state", "delete" }, new string[] { "Responders", "Set State", "<Delete>" });
                }

                string result = Engine.Menu(menu, title: task.ToString());
                switch (result)
                {
                    case "show_tasks":
                        EpicTaskTasksWindow(task as EpicTask);
                        break;
                    case "show_responders":
                        ShowRespondersWindow(task);
                        break;
                    case "state":
                        SetStateDialog(task);
                        break;
                    case "delete":
                        foreach(IAssignable temp in Tasks)
                        {
                            if(temp is EpicTask)
                            {
                                (temp as EpicTask).RemoveTask(task);
                            }
                        }
                        foreach(Project project in Projects)
                        {
                            project.RemoveTask(task);
                        }
                        Tasks.Remove(task);
                        DBManager.SaveChanges();
                        return;
                    case null:
                        return;
                }
            }
        }
    }
}
