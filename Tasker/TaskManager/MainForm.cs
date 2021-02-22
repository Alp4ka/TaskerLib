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
        //delegate void UsersHandler(MetroPanel mpanel, int distance);
        //event UsersHandler UsersChanged;

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
                button.Controls.Add(mpb);
                mpb.Location = new Point(button.Width - mpb.Width,
                                          0);
                projectsPanel.Controls.Add(button);
            }
            RecalculateChildren(projectsPanel, 20);
        }
        public void InitializeUsersView()
        {
            usersPanel.Controls.Clear();
            foreach(User user in Users)
            {
                MetroTile button = new MetroTile();
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = user.ID.ToString();
                button.Text = $"{user.ID}: {user.Fullname}";
                button.Width = usersPanel.Width;
                button.Height = 50;
                usersPanel.Controls.Add(button);
            }
            RecalculateChildren(usersPanel, 20);
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
            DBManager.Connection.Close();
            DBManager.SaveChanges();
            Environment.Exit(0);
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
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
    }
}
