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
        private static readonly string _dbPath = @".\db.db";
        private static SQLiteConnection _connection;
        private static List<User> _users = new List<User>();
        private static List<Project> _projects = new List<Project>();
        static void Main(string[] args)
        {
            Console.CancelKeyPress += CancelKeyPress;
            InitializeDatabase();
            ReadDataBase();
            Console.WriteLine(String.Join("\n", _users));
            _users.Clear();
            _users.Add(new User("Pasha", "Durov", 100));
            _users.Add(new User("Roma", "Gorkovets", 10));
            //User user1 = new User("Roman", "Gorkovets");
            //User user2 = new User("Bogdan", "Kulikov", 1100);
            //_users = new List<User>(new User[] { user1, user2 });
            /*Console.WriteLine(command.ExecuteNonQuery());
            command = new SQLiteCommand("SELECT * FROM 'Users';", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string Name = record["Name"].ToString();
                string Surname = record["Surname"].ToString();
                int Experience = int.Parse(record["Experience"].ToString());
                User copy = new User(Name, Surname, Experience);
                Console.WriteLine(copy);
            }

            connection.Close();
            */



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
        static void InitializeDatabase()
        {
            
            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                _connection = new SQLiteConnection(string.Format("Data Source={0};", _dbPath));
                _connection.Open();
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE Users (id INTEGER , Name TEXT, Surname TEXT, Experience INTEGER);" +
                                                          "CREATE TABLE Tasks (id INTEGER , Name TEXT, Description TEXT, Responders TEXT, State INTEGER);" +
                                                          "CREATE TABLE Bugs (id INTEGER , Name TEXT, Description TEXT, Responders TEXT, State INTEGER);" +
                                                          "CREATE TABLE StoryTasks (id INTEGER , Name TEXT, Description TEXT, Responders TEXT, State INTEGER);" +
                                                          "CREATE TABLE EpicTasks (id INTEGER , Name TEXT, Description TEXT, Tasks TEXT, State INTEGER);" +
                                                          "CREATE TABLE Projects (id INTEGER , Name TEXT, Description TEXT, Tasks TEXT);", _connection);
                command.ExecuteNonQuery();
                _connection.Close();
            }
            else
            {
                _connection = new SQLiteConnection(string.Format("Data Source={0};", _dbPath));
                _connection.Close();
            }
        }
        static void ReadDataBase()
        {
            if (File.Exists(_dbPath))
            {
                ReadUsers();
            }
        }
        static void ReadUsers()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Users';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string Name = record["Name"].ToString();
                string Surname = record["Surname"].ToString();
                int Experience = int.Parse(record["Experience"].ToString());
                try
                {
                    User temp = new User(Name, Surname, Experience);
                    _users.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
        static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _connection.Close();
            SaveChanges();
            Environment.Exit(1);
        }
        static void SaveChanges()
        {
            SaveUsers();
            SaveTasks();
            SaveProjects();
            
        }
        static void SaveUsers()
        {
            SQLiteCommand command;
            _connection.Open();
            command = new SQLiteCommand("DELETE FROM Users; VACUUM;", _connection);
            command.ExecuteNonQuery();
            int cnt = 0;
            foreach (User user in _users)
            {
                command = new SQLiteCommand($"INSERT INTO 'Users' ('id', 'Name', 'Surname', 'Experience') VALUES ({cnt}, '{user.Name}', '{user.Surname}', '{user.Experience}');", _connection);
                command.ExecuteNonQuery();
                cnt++;
            }
            _connection.Close();
        }
        static void SaveProjects()
        {

        }
    }
}
