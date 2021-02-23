using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using Tasker;
using TaskerConsole;

namespace TaskManager
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public static List<User> Users = DBManager._users;
        public static List<Project> Projects = DBManager._projects;
        public static List<IAssignable> Tasks = DBManager._tasks;
        private static int _maxProjects = 3;
        public MainForm()
        {
            DBManager.SetPath(@".\db.db");
            DBManager.InitializeDatabase();
            DBManager.ReadDataBase();
            InitializeComponent();
            warningLabel.Text = "";
            warningProj.Text = "";
            InitializeUsersView();
            InitializeProjectsView();
        }
        public static User GetUserByID(int id)
        {
            return Users.Find(x => x.ID == id);
        }
        public static Project GetProjectByID(int id)
        {
            return Projects.Find(x => x.ID == id);
        }
        public static IAssignable GetTaskByID(int id)
        {
            return Tasks.Find(x => x.ID == id);
        }
        public void InitializeProjectsView()
        {
            projectsPanel.Controls.Clear();
            foreach (Project project in Projects)
            {
                MetroProgressBar mpb = new MetroProgressBar();
                mpb.Width = usersPanel.Width;
                mpb.Height = 5;
                mpb.Maximum = 100;
                mpb.Theme = MetroFramework.MetroThemeStyle.Dark;
                mpb.Style = MetroFramework.MetroColorStyle.Green;
                mpb.Value = (int)project.Percentage;
                MetroTile button = new MetroTile();
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = project.ID.ToString();
                button.Text = $"{project.ID}: {project.Name}";
                button.Width = usersPanel.Width;
                button.Height = 50;
                button.Theme = MetroFramework.MetroThemeStyle.Dark;
                button.Controls.Add(mpb);
                button.Click += ProjectButtonClick;
                mpb.Location = new Point(button.Width - mpb.Width, 0);
                projectsPanel.Controls.Add(button);


                MetroTile delBtn = new MetroTile();
                delBtn.TextAlign = ContentAlignment.MiddleCenter;
                delBtn.Name = project.ID.ToString() + "R";
                delBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
                delBtn.Style = MetroFramework.MetroColorStyle.Red;
                delBtn.Text = $"-";
                delBtn.Width = 50;
                delBtn.Height = 50;
                delBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
                delBtn.Location = new Point(usersPanel.Width - 50, 0);
                delBtn.Click += DeleteProjectByClick;
                button.Controls.Add(delBtn);

            }
            RecalculateChildren(projectsPanel, 10);
        }
        public void ProjectButtonClick(object sender, EventArgs e)
        {
            ShowProjectInfo(GetProjectByID(int.Parse((sender as Control).Name)));
        }
        private void ShowProjectInfo(Project project)
        {
            ProjectView pv = new ProjectView(project);
            pv.ShowDialog();
            InitializeProjectsView();
        }
        private void ShowUserInfo(User user)
        {
            UserPage up = new UserPage();
            up.userNameLabel.Text = user.Name;
            up.userSurnameLabel.Text = user.Surname;
            up.userIdLabel.Text = user.ID.ToString();
            up.userRankLabel.Text = user.Rank;
            up.ShowDialog();
        }
        public void UserButtonClick(object sender, EventArgs e)
        {
            ShowUserInfo(GetUserByID(int.Parse((sender as Control).Name)));
        }
        public void InitializeUsersView()
        {
            usersPanel.Controls.Clear();
            // user buttons.
            foreach (User user in Users)
            {
                MetroTile button = new MetroTile();
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = user.ID.ToString();
                button.Text = $"{user.ID}: {user.Fullname}";
                button.Width = usersPanel.Width;
                button.Height = 50;
                button.Theme = MetroFramework.MetroThemeStyle.Dark;
                button.Click += UserButtonClick;
                usersPanel.Controls.Add(button);

                MetroTile delBtn = new MetroTile();
                delBtn.TextAlign = ContentAlignment.MiddleCenter;
                delBtn.Name = user.ID.ToString() + "R";
                delBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
                delBtn.Style = MetroFramework.MetroColorStyle.Red;
                delBtn.Text = $"-";
                delBtn.Width = 50;
                delBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
                delBtn.Location = new Point(button.Width - delBtn.Width, 0);
                delBtn.Height = 50;
                delBtn.Click += DeleteUserByClick;
                button.Controls.Add(delBtn);
            }
            RecalculateChildren(usersPanel, 10);
        }
        private void DeleteUserByClick(object sender, EventArgs e)
        {
            // Name = ID+'R'
            int id;
            if (int.TryParse((sender as Control).Name.Replace("R", ""), out id))
            {
                User user = GetUserByID(id);
                if (user == default)
                {
                    return;
                }
                else
                {
                    Users.Remove(user);
                    DBManager.SaveChanges();
                    InitializeUsersView();
                }
            }
            else
            {
                return;
            }
        }
        private void DeleteProjectByClick(object sender, EventArgs e)
        {
            // Name = ID+'R'
            int id;
            if (int.TryParse((sender as Control).Name.Replace("R", ""), out id))
            {
                Project project = GetProjectByID(id);
                if (project == default)
                {
                    return;
                }
                else
                {
                    Projects.Remove(project);
                    DBManager.SaveChanges();
                    InitializeProjectsView();
                }
            }
            else
            {
                return;
            }
        }

        private void RecalculateChildren(MetroPanel mpanel, int distance = 20)
        {
            MetroTile[] children = mpanel.Controls.OfType<MetroTile>().ToArray();
            for (int i = 0; i < children.Length; ++i)
            {
                children[i].Location = new Point((mpanel.Width - children[i].Width) / 2,
                                                distance * (i) + i * children[i].Height);
            }
        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = projectsPage;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            DBManager.Connection.Close();
            DBManager.SaveChanges();
            Environment.Exit(0);
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = usersPage;
        }

        private void createNewUserButton_Click(object sender, EventArgs e)
        {
            if (!User.CheckName(newUserNameTb.Text))
            {
                warningLabel.Text = "Wrong value for user name!";
                return;
            }
            if (!User.CheckSurname(newUserSurnameTb.Text))
            {
                warningLabel.Text = "Wrong value for user surname!";
                return;
            }
            User user = new User(newUserNameTb.Text, newUserSurnameTb.Text);
            Users.Add(user);
            DBManager.SaveChanges();
            warningLabel.Text = "Success!";
            InitializeUsersView();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            if(Projects.Count >= _maxProjects)
            {
                warningProj.Text = $"Too much projects ({Projects.Count}/{_maxProjects})!";
                return;
            }
            if (!Project.CheckName(newProjectNameTb.Text))
            {
                warningProj.Text = "Wrong value for project name!";
                return;
            }
            Project project = new Project(newProjectNameTb.Text, newProjectDescrTb.Text);
            Projects.Add(project);
            DBManager.SaveChanges();
            warningProj.Text = "Success!";
            InitializeProjectsView();
        }

        private void controlExitButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void rollUpButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
