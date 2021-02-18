using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;
using Tasker;

namespace TaskerConsole
{
    public static class DBManager
    {
        private static string _dbPath;
        private static SQLiteConnection _connection;
        public static List<User> _users = new List<User>();
        public static List<Project> _projects = new List<Project>();
        public static List<IAssignable> _tasks = new List<IAssignable>();
        public static SQLiteConnection Connection {get=>_connection;}
        public static void SetPath(string path)
        {
            _dbPath = path;
        }
        public static void SendCommand(string commandToSend)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(commandToSend, _connection);
            _connection.Close();
        }
        public static void InitializeDatabase()
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
        public static string Path {get => _dbPath;}
        public static void ReadDataBase()
        {
            if (File.Exists(_dbPath))
            {
                ReadUsers();
                ReadListing();
                //ReadProjects();
            }
        }
        static void ReadListing()
        {
            ReadTasks();
            ReadBugs();
            ReadStoryTasks();
            ReadEpicTasks();
        }
        static void ReadTasks()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Tasks';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string name = record["Name"].ToString();
                string description = record["Description"].ToString();
                User responder = ParseResponders(record["Responders"].ToString())[0];
                var state = (BaseTask.TaskState)int.Parse(record["State"].ToString());
                try
                {
                    Task temp = new Task(name, description, state: state, responder: responder);
                    temp.ID = id;
                    _tasks.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
        static List<User> ParseResponders(string input)
        {
            int[] ids = input.Split().Select(x => int.Parse(x)).ToArray();
            var result = new List<User>();
            foreach (int id in ids)
            {
                var user = _users.Find(x => x.ID == id);
                if (user != default(User))
                {
                    result.Add(user);
                }
            }
            return result;
        }
        static List<IAssignable> ParseTasks(string input)
        {
            int[] ids = input.Split().Select(x => int.Parse(x)).ToArray();
            var result = new List<IAssignable>();
            foreach (int id in ids)
            {
                var task = _tasks.Find(x => x.ID == id);
                if (task != default(BaseTask) && !(task is EpicTask))
                {
                    result.Add(task);
                }
            }
            return result;
        }
        static void ReadUsers()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Users';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string name = record["Name"].ToString();
                string surname = record["Surname"].ToString();
                int experience = int.Parse(record["Experience"].ToString());
                try
                {
                    User temp = new User(name, surname, experience);
                    temp.ID = id;
                    _users.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
        public static void SaveChanges()
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
                user.ID = cnt;
                cnt++;
            }
            _connection.Close();
        }
        //TODO
        static void SaveProjects()
        {

        }
        static void SaveTasks()
        {
            List<IAssignable> toSave = new List<IAssignable>();
            List<KeyValuePair<EpicTask, int>> epics = new List<KeyValuePair<EpicTask, int>>();
            int cnt = 0;
            _connection.Open();
            //Что будет, если насрать в вакуум? ... В вакууме будет насрано. Заклинаю, SQL для быдла.
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Tasks; VACUUM;" +
                                                      "DELETE FROM Bugs; VACUUM;" +
                                                      "DELETE FROM StoryTasks; VACUUM;" +
                                                      "DELETE FROM EpicTasks; VACUUM;", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            foreach (IAssignable task in _tasks)
            {
                if (task is EpicTask)
                {
                    epics.Add(new KeyValuePair<EpicTask, int>(task as EpicTask, cnt));
                }
                else if (task is Bug)
                {
                    SaveBug(task as Bug, cnt);
                }
                else if (task is Task)
                {
                    SaveTask(task as Task, cnt);
                }
                else if (task is StoryTask)
                {
                    SaveStoryTask(task as StoryTask, cnt);
                }
                cnt++;
            }
            foreach (KeyValuePair<EpicTask, int> KeyValueEpic in epics)
            {
                SaveEpicTask(KeyValueEpic.Key, KeyValueEpic.Value);
            }

        }
        static void SaveEpicTask(EpicTask epicTask, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({ id}, '{epicTask.Name}', '{epicTask.Description}', '{String.Join(" ", epicTask.GetTasks().Select(x => x.ID))}', { (int)epicTask.State})";
            command = new SQLiteCommand($"INSERT INTO 'EpicTasks' ('id', 'Name', 'Description', 'Tasks', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            epicTask.ID = id;
        }
        static void SaveBug(Bug bug, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{bug.Name}', '{bug.Description}', '{String.Join(" ", bug.Responders.Select(x => x.ID))}', {(int)bug.State})";
            command = new SQLiteCommand($"INSERT INTO 'Bugs' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            bug.ID = id;
        }
        static void SaveTask(Task task, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{task.Name}', '{task.Description}', '{String.Join(" ", task.Responders.Select(x => x.ID))}', {(int)task.State})";
            command = new SQLiteCommand($"INSERT INTO 'Tasks' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            task.ID = id;
        }
        static void SaveStoryTask(StoryTask storyTask, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{storyTask.Name}', '{storyTask.Description}', '{String.Join(" ", storyTask.Responders.Select(x => x.ID))}', {(int)storyTask.State})";
            command = new SQLiteCommand($"INSERT INTO 'StoryTasks' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            storyTask.ID = id;
        }
        static void ReadBugs()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Bugs';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string name = record["Name"].ToString();
                string description = record["Description"].ToString();
                User responder = ParseResponders(record["Responders"].ToString())[0];
                var state = (BaseTask.TaskState)int.Parse(record["State"].ToString());
                try
                {
                    Bug temp = new Bug(name, description, state: state, responder: responder);
                    temp.ID = id;
                    _tasks.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
        static void ReadStoryTasks()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'StoryTasks';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string name = record["Name"].ToString();
                string description = record["Description"].ToString();
                List<User> responders = ParseResponders(record["Responders"].ToString());
                var state = (BaseTask.TaskState)int.Parse(record["State"].ToString());
                try
                {
                    StoryTask temp = new StoryTask(name, description, state: state, responders: responders);
                    temp.ID = id;
                    _tasks.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
        static void ReadEpicTasks()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'EpicTasks';", _connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                int id = int.Parse(record["id"].ToString());
                string name = record["Name"].ToString();
                string description = record["Description"].ToString();
                List<IAssignable> tasks = ParseTasks(record["Tasks"].ToString());
                var state = (BaseTask.TaskState)int.Parse(record["State"].ToString());
                try
                {
                    EpicTask temp = new EpicTask(name, description, state: state, tasks: tasks);
                    temp.ID = id;
                    _tasks.Add(temp);
                }
                catch
                {

                }
            }
            _connection.Close();
        }
    }
}
