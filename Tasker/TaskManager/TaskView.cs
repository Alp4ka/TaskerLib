using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tasker;
using TaskerConsole;
using MetroFramework.Controls;

namespace TaskManager
{
    public partial class TaskView : MetroFramework.Forms.MetroForm
    {
        IAssignable _task;
        object _parent;
        private bool click = false;
        private Color _originalColor;
        private Color _pickColor;
        public TaskView()
        {
            InitializeComponent();
        }
        public TaskView(IAssignable task, object parent) : this()
        {
            showTasksBtn.Visible = false;
            if (task is EpicTask)
            {
                Style = MetroFramework.MetroColorStyle.Purple;
                showTasksBtn.Visible = true;
            }
            else if (task is Task)
            {
                Style = MetroFramework.MetroColorStyle.Blue;

            }
            else if (task is Bug)
            {
                Style = MetroFramework.MetroColorStyle.Red;
            }
            else if (task is StoryTask)
            {
                Style = MetroFramework.MetroColorStyle.Orange;
            }
            _task = task;
            _parent = parent;
            descriptionTb.Text = task.Description;
            Text = task.Name;
            _originalColor = Color.FromArgb(22, 22, 22);
            _pickColor = Color.FromArgb(_originalColor.R + 10,
                                   _originalColor.G + 10,
                                   _originalColor.B + 10);
            ReloadResponders();
            RecalculateAll();
        }

        /// <summary>
        /// Get color by task type.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
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
            else if (task is StoryTask)
            {
                return Color.Orange;
            }
            else if (task is EpicTask)
            {
                return Color.Purple;
            }
            else
            {
                return Color.Gray;
            }
        }

        /// <summary>
        /// Reload responders.
        /// </summary>
        private void ReloadResponders()
        {
            respondersPanel.Controls.Clear();
            usersPanel.Controls.Clear();
            List<User> responders = _task.GetResponders();
            List<User> users = MainForm.Users.Except(responders).ToList();
            foreach (User user in responders)
            {
                MetroTile button = new MetroTile();
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = user.ID.ToString();
                button.Text = $"{user.Fullname}";
                button.MouseDown += TileMouseDown;
                button.MouseUp += TileMouseUp;
                button.Width = respondersPanel.Width;
                button.Height = 50;
                button.Theme = MetroFramework.MetroThemeStyle.Dark;
                respondersPanel.Controls.Add(button);
            }
            foreach (User user in users)
            {
                MetroTile button = new MetroTile();
                button.TextAlign = ContentAlignment.MiddleLeft;
                button.Name = user.ID.ToString();
                button.Text = $"{user.Fullname}";
                button.MouseDown += TileMouseDown;
                button.MouseUp += TileMouseUp;
                button.Width = respondersPanel.Width;
                button.Height = 50;
                button.Theme = MetroFramework.MetroThemeStyle.Dark;
                usersPanel.Controls.Add(button);
            }
        }


        /// <summary>
        /// Event tile mouse down handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileMouseDown(object sender, MouseEventArgs e)
        {
            click = true;
        }

        /// <summary>
        /// Recalculate children.
        /// </summary>
        /// <param name="mpanel"></param>
        /// <param name="distance"></param>
        private void RecalculateChildren(MetroPanel mpanel, int distance = 20)
        {
            MetroTile[] children = mpanel.Controls.OfType<MetroTile>().ToArray();
            for (int i = 0; i < children.Length; ++i)
            {
                children[i].Location = new Point((mpanel.Width - children[i].Width) / 2,
                                                distance * (i) + i * children[i].Height);
            }
        }

        /// <summary>
        /// Recalculate all panels.
        /// </summary>
        private void RecalculateAll()
        {
            foreach (var panel in Controls.OfType<MetroPanel>())
            {
                RecalculateChildren(panel);
            }
        }

        /// <summary>
        /// Tile mouse up event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        var user = MainForm.GetUserByID(int.Parse((sender as MetroTile).Name));
                        switch (panel.Name)
                        {
                            case "usersPanel":
                                _task.RemoveResponder(user);
                                break;
                            case "respondersPanel":
                                _task.AddResponder(user);
                                break;
                            default:
                                break;
                        }
                        RecalculateAll();
                        click = false;
                        return;
                    }

                }

            }
            click = false;
        }

        /// <summary>
        /// Remove button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeFromBtn_Click(object sender, EventArgs e)
        {
            if (_parent is Project)
            {
                (_parent as Project).RemoveTask(_task);
                DBManager.ReloadDB();
                Close();
            }
            else if (_parent is EpicTask)
            {
                (_parent as EpicTask).RemoveTask(_task);
                DBManager.ReloadDB();
                Close();
            }
        }

        /// <summary>
        /// Show tasks button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showTasksBtn_Click(object sender, EventArgs e)
        {
            if (_task is EpicTask)
            {
                var pv = new ProjectView(_task as EpicTask);
                pv.ShowDialog();
                DBManager.SaveChanges();
            }
        }
    }
}
