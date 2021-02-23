using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Controls;
using Tasker;
using System.Collections.Generic;
using TaskerConsole;

namespace TaskManager
{
    public partial class ProjectView : MetroFramework.Forms.MetroForm
    {
        private Project _project;
        private EpicTask _epicTask;
        private bool click = false;
        private Color _originalColor;
        private Color _pickColor;
        public ProjectView()
        {
            InitializeComponent();
        }
        public ProjectView(Project project):this()
        {
            _project = project;
            Text = project.Name;
            _originalColor = Color.FromArgb(22, 22, 22);
            _pickColor = Color.FromArgb(_originalColor.R + 10,
                                   _originalColor.G + 10,
                                   _originalColor.B+10);
            ReloadTasks();
            RecalculateAll();
        }
        public ProjectView(EpicTask epic) : this()
        {
            _epicTask = epic;
            Text = epic.Name;
            _originalColor = Color.FromArgb(22, 22, 22);
            _pickColor = Color.FromArgb(_originalColor.R + 10,
                                   _originalColor.G + 10,
                                   _originalColor.B + 10);
            ReloadTasks();
            RecalculateAll();
        }
        private void ReloadTasks()
        {
            openPanel.Controls.Clear();
            progressPanel.Controls.Clear();
            closedPanel.Controls.Clear();
            List<IAssignable> tasks;
            if (_epicTask != null)
            {
                tasks = _epicTask.GetTasks();
            }
            else
            {
                progressBar.Value = (int)_project.Percentage;
                tasks = _project.GetTasks();
            }
            foreach (IAssignable task in tasks)
            {
                MetroTile button = new MetroTile();
                button.CustomBackground = true;
                button.BackColor = TaskColorByContext(task);
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = task.ID.ToString();
                button.Text = $"{task.Name}";
                button.MouseDown += TileMouseDown;
                button.MouseUp += TileMouseUp;
                button.MouseMove += TileMouseMove;
                button.Click += ShowTaskView;
                button.Width = openPanel.Width;
                button.Height = 50;
                button.Theme = MetroFramework.MetroThemeStyle.Dark;
                switch ((task as BaseTask).State)
                {
                    case BaseTask.TaskState.Open:
                        openPanel.Controls.Add(button);
                        break;
                    case BaseTask.TaskState.InProgress:
                        progressPanel.Controls.Add(button);
                        break;
                    case BaseTask.TaskState.Closed:
                        closedPanel.Controls.Add(button);
                        break;
                }
            }
        }
        private void ShowTaskView(object sender, System.EventArgs e)
        {
            object parent;
            if(_epicTask == null)
            {
                parent = _project;
            }
            else
            {
                parent = _epicTask;
            }
            var tv = new TaskView(MainForm.GetTaskByID(int.Parse((sender as Control).Name)), parent);
            tv.ShowDialog();
            DBManager.SaveChanges();
            ReloadTasks();
            RecalculateAll();
        }
        private Color TaskColorByContext(IAssignable task)
        {
            if (task is Bug)
            {
                return Color.Red;
            }
            else if (task is Task)
            {
                return Color.Blue;
            }
            else if(task is StoryTask)
            {
                return Color.Orange;
            }
            else if(task is EpicTask)
            {
                return Color.Purple;
            }
            else
            {
                return Color.Gray;
            }
        }
        private void TileMouseDown(object sender, MouseEventArgs e)
        {
            click = true;
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
        private void RecalculateAll()
        {
            if(_project != null)
            {
                progressBar.Value = (int)_project.Percentage;
            }
            
            foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
            {
                RecalculateChildren(panel);
            }
        }
        private void TileMouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (click)
            {
                foreach (var panel in Controls.OfType<MetroPanel>())
                {
                    panel.BackColor = _originalColor;
                }
                foreach (var panel in Controls.OfType<MetroPanel>())
                {
                    if (panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                    {
                        (sender as MetroTile).Parent = panel;
                        var task = MainForm.GetTaskByID(int.Parse((sender as MetroTile).Name));
                        switch (panel.Name)
                        {
                            case "openPanel":
                                (task as BaseTask).SetState(BaseTask.TaskState.Open);
                                break;
                            case "progressPanel":
                                (task as BaseTask).SetState(BaseTask.TaskState.InProgress);
                                break;
                            case "closedPanel":
                                (task as BaseTask).SetState(BaseTask.TaskState.Closed);
                                break;
                        }
                        ReloadTasks();
                        RecalculateAll();
                        click = false;
                        return;
                    }

                }

            }
            click = false;
        }

        private void TileMouseMove(object sender, MouseEventArgs e)
        {

            if (click)
            {
                foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
                {
                    if (panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)) &&
                        panel != (sender as MetroTile).Parent)
                    {
                        panel.BackColor = _pickColor;
                    }
                    else
                    {
                        panel.BackColor = _originalColor;
                    }
                }
                Cursor = Cursors.Hand;
            }
        }

        private void rollUpButton_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void controlExitButton_Click(object sender, System.EventArgs e)
        {
            CloseForm();
        }
        private void CloseForm()
        {
            DBManager.Connection.Close();
            DBManager.SaveChanges();
            this.Close();
        }
        private void AddTask(BaseTask.TaskState state, Project project)
        {
            TaskCreationView tcv = new TaskCreationView(project, state);
            tcv.ShowDialog();
            DBManager.SaveChanges();
        }
        private void AddTask(BaseTask.TaskState state, EpicTask epicTask)
        {
            TaskCreationView tcv = new TaskCreationView(epicTask, state);
            tcv.ShowDialog();
            DBManager.SaveChanges();
        }
        /// <summary>
        /// Просто не смотрите на эти ифы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTaskButtonClick(object sender, System.EventArgs e)
        {
            if(_project != null)
            {
                switch ((sender as Control).Name)
                {
                    case "addOpenTaskTile":
                        AddTask(BaseTask.TaskState.Open, _project);
                        break;
                    case "addProgressTaskTile":
                        AddTask(BaseTask.TaskState.InProgress, _project);
                        break;
                    case "addClosedTaskTile":
                        AddTask(BaseTask.TaskState.Closed, _project);
                        break;
                }
            }
            else
            {
                switch ((sender as Control).Name)
                {
                    case "addOpenTaskTile":
                        AddTask(BaseTask.TaskState.Open, _epicTask);
                        break;
                    case "addProgressTaskTile":
                        AddTask(BaseTask.TaskState.InProgress, _epicTask);
                        break;
                    case "addClosedTaskTile":
                        AddTask(BaseTask.TaskState.Closed, _epicTask);
                        break;
                }
            }
            DBManager.SaveChanges();
            ReloadTasks();
            RecalculateAll();
        }
    }
}
