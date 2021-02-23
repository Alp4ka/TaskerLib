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
        public static SQLiteConnection Connection { get => _connection; }
        public static void SetPath(string path)
        {
            _dbPath = path;
        }

        /// <summary>
        /// Send command.
        /// </summary>
        /// <param name="commandToSend"> SQL command. </param>
        public static void SendCommand(string commandToSend)
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand(commandToSend, _connection);
            _connection.Close();
        }


        /// <summary>
        /// Initialize database.
        /// </summary>
        public static void InitializeDatabase()
        {

            if (!File.Exists(_dbPath))
            {
                SQLiteConnection.CreateFile(_dbPath);
                _connection = new SQLiteConnection(string.Format("Data Source={0};", _dbPath));
                _connection.Open();
                // Даже не пишите, что можно юзать ForeignKey'и. Я уже дед инсайд, просто сожгите эту ненужную мясную оболочку 
                // и я полечу покорять астральное пространство своим говнокодом.
                // Меня на этой планете уже ничего не держит. Делайте че хотите, но не снижайте за кодстайл.
                // З.Ы. Пользуясь случаем, хочу передать привет всем, кто делает автосейв через сериализацию.
                // Осуждаю и завидую. Завидую, оттого и осуждаю.*
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
        public static string Path { get => _dbPath; }

        /// <summary>
        /// Read database.
        /// </summary>
        public static void ReadDataBase()
        {
            if (File.Exists(_dbPath))
            {
                ReadUsers();
                ReadListing();
                ReadProjects();
            }
        }

        /// <summary>
        /// Read projects.
        /// </summary>
        private static void ReadProjects()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Projects';", _connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    int id = int.Parse(record["id"].ToString());
                    string name = record["Name"].ToString();
                    string description = record["Description"].ToString();
                    List<IAssignable> tasks = ParseTasks(record["Tasks"].ToString());
                    try
                    {
                        Project temp = new Project(name, description, tasks: tasks);
                        temp.ID = id;
                        _projects.Add(temp);
                    }
                    catch
                    {
                    }
                }
            }
            _connection.Close();
        }

        /// <summary>
        /// Read all types of tasks.
        /// </summary>
        private static void ReadListing()
        {
            ReadTasks();
            ReadBugs();
            ReadStoryTasks();
            ReadEpicTasks();
        }

        /// <summary>
        /// Read all tasks.
        /// </summary>
        private static void ReadTasks()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Tasks';", _connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    int id = int.Parse(record["id"].ToString());
                    string name = record["Name"].ToString();
                    string description = record["Description"].ToString();

                    User responder;
                    List<User> tempList = ParseResponders(record["Responders"].ToString());
                    if (tempList.Count < 1)
                    {
                        responder = null;
                    }
                    else
                    {
                        responder = tempList[0];
                    }
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
            }
            _connection.Close();
        }

        /// <summary>
        /// Parse responders from string.
        /// </summary>
        /// <param name="input"> String withg data. </param>
        /// <returns> List of responders. </returns>
        private static List<User> ParseResponders(string input)
        {
            if (input is null || String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input) || input == "NULL")
            {
                return new List<User>();
            }
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

        /// <summary>
        /// Parse tasks from string.
        /// </summary>
        /// <param name="input"> String with data. </param>
        /// <returns> List of tasks. </returns>
        private static List<IAssignable> ParseTasks(string input)
        {
            if (input is null || String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input) || input == "NULL")
            {
                return new List<IAssignable>();
            }
            int[] ids = input.Split().Select(x => int.Parse(x)).ToArray();
            var result = new List<IAssignable>();
            foreach (int id in ids)
            {
                var task = _tasks.Find(x => x.ID == id);
                if (task != default(IAssignable))
                {
                    result.Add(task);
                }
            }
            return result;
        }


        /// <summary>
        /// Read users data.
        /// </summary>
        private static void ReadUsers()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Users';", _connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
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
            }
            _connection.Close();
        }

        /// <summary>
        /// Reload Database.
        /// </summary>
        public static void ReloadDB()
        {
            //Connection.Close();
            SaveChanges();
            _projects.Clear();
            _users.Clear();
            _tasks.Clear();
            ReadDataBase();
        }

        /// <summary>
        /// Save all changes.
        /// </summary>
        public static void SaveChanges()
        {
            SaveUsers();
            SaveTasks();
            SaveProjects();
        }

        /// <summary>
        /// Save users.
        /// </summary>
        private static void SaveUsers()
        {
            SQLiteCommand command;
            _connection.Close();
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

        /// <summary>
        /// Save projects.
        /// </summary>
        private static void SaveProjects()
        {
            SQLiteCommand command;
            _connection.Open();
            command = new SQLiteCommand("DELETE FROM Projects; VACUUM;", _connection);
            command.ExecuteNonQuery();
            int cnt = 0;
            foreach (Project project in _projects)
            {
                string value = $"({cnt}, '{project.Name}', '{project.Description}', '{String.Join(" ", project.GetTasks().Select(x => x.ID))}')";
                command = new SQLiteCommand($"INSERT INTO 'Projects' ('id', 'Name', 'Description', 'Tasks') VALUES {value};", _connection);
                command.ExecuteNonQuery();
                project.ID = cnt;
                cnt++;
            }
            _connection.Close();
        }

        /// <summary>
        /// Save all tasks.
        /// </summary>
        private static void SaveTasks()
        {
            List<IAssignable> toSave = new List<IAssignable>();
            List<KeyValuePair<EpicTask, int>> epics = new List<KeyValuePair<EpicTask, int>>();
            int cnt = 0;
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Tasks; VACUUM;" +             // Что будет, если насрать в вакуум? ... В вакууме будет насрано.
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

        /// <summary>
        /// Save epictask data.
        /// </summary>
        /// <param name="epicTask"></param>
        /// <param name="id"></param>
        private static void SaveEpicTask(EpicTask epicTask, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({ id}, '{epicTask.Name}', '{epicTask.Description}', '{String.Join(" ", epicTask.GetTasks().Select(x => x.ID))}', { (int)epicTask.State})";
            command = new SQLiteCommand($"INSERT INTO 'EpicTasks' ('id', 'Name', 'Description', 'Tasks', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            epicTask.ID = id;
        }

        /// <summary>
        /// Save data about bug.
        /// </summary>
        private static void SaveBug(Bug bug, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{bug.Name}', '{bug.Description}', '{String.Join(" ", bug.Responders.Select(x => x.ID))}', {(int)bug.State})";
            command = new SQLiteCommand($"INSERT INTO 'Bugs' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            bug.ID = id;
        }

        /// <summary>
        /// Save data about task.
        /// </summary>
        private static void SaveTask(Task task, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{task.Name}', '{task.Description}', '{String.Join(" ", task.Responders.Select(x => x.ID))}', {(int)task.State})";
            command = new SQLiteCommand($"INSERT INTO 'Tasks' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            task.ID = id;
        }

        /// <summary>
        /// Save data about stories.
        /// </summary>
        private static void SaveStoryTask(StoryTask storyTask, int id)
        {
            SQLiteCommand command;
            _connection.Open();
            string value = $"({id}, '{storyTask.Name}', '{storyTask.Description}', '{String.Join(" ", storyTask.Responders.Select(x => x.ID))}', {(int)storyTask.State})";
            command = new SQLiteCommand($"INSERT INTO 'StoryTasks' ('id', 'Name', 'Description', 'Responders', 'State') VALUES {value};", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
            storyTask.ID = id;
        }

        /// <summary>
        /// Read data about bugs.
        /// </summary>
        private static void ReadBugs()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Bugs';", _connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                foreach (DbDataRecord record in reader)
                {
                    int id = int.Parse(record["id"].ToString());
                    string name = record["Name"].ToString();
                    string description = record["Description"].ToString();
                    List<User> result = ParseResponders(record["Responders"].ToString());
                    if (result.Count < 1)
                    {
                        return;
                    }
                    else
                    {
                        User responder = result[0];
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

                }
            }
            _connection.Close();

        }

        /// <summary>
        /// Read story tasks.
        /// </summary>
        private static void ReadStoryTasks()
        {
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'StoryTasks';", _connection);
            if (_connection.State != System.Data.ConnectionState.Open)
            {
                _connection.Open();
            }

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
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
            }
            _connection.Close();
        }

        /// <summary>
        /// Read epic tasks.
        /// </summary>
        private static void ReadEpicTasks()
        {
            _connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'EpicTasks';", _connection);
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
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
            }
            _connection.Close();
        }
    }
}
