using System;
using Tasker;

namespace TaskManager
{
    public partial class TaskCreationView : MetroFramework.Forms.MetroForm
    {
        enum Mode
        {
            Project = 1,
            EpicTask = 2
        }
        Mode _mode;
        Project _project;
        EpicTask _epicTask;
        BaseTask.TaskState _state;
        string[] _comboView;
        public TaskCreationView()
        {
            InitializeComponent();
        }
        public TaskCreationView(Project project, BaseTask.TaskState state) : this()
        {
            _mode = Mode.Project;
            _state = state;
            _project = project;
            _comboView = new string[] { "Task", "StoryTask", "EpicTask", "Bug"};
            typeBox.Items.AddRange(_comboView);
        }
        public TaskCreationView(EpicTask epic, BaseTask.TaskState state) : this()
        {
            _mode = Mode.EpicTask;
            _state = state;
            _epicTask = epic;
            _comboView = new string[] {"Task", "StoryTask"};
            typeBox.Items.AddRange(_comboView);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!BaseTask.CheckName(nameTb.Text))
            {
                //warningLabel.Text = "Wrong value for user name!";
                return;
            }
            IAssignable task;
            switch (typeBox.Text)
            {
                case "Task":
                    task = new Task(nameTb.Text, descriptionTb.Text, _state);
                    break;
                case "StoryTask":
                    task = new StoryTask(nameTb.Text, descriptionTb.Text, _state);
                    break;
                case "EpicTask":
                    task = new EpicTask(nameTb.Text, descriptionTb.Text, _state);
                    break;
                case "Bug":
                    task = new Bug(nameTb.Text, descriptionTb.Text, _state);
                    break;
                default:
                    task = new Task(nameTb.Text, descriptionTb.Text, _state);
                    break;
            }
            switch (_mode)
            {
                case Mode.EpicTask:
                    MainForm.Tasks.Add(task);
                   _epicTask.AddTask(task);
                    break;
                case Mode.Project:
                    MainForm.Tasks.Add(task);
                    _project.AddTask(task);
                    break;
            }
            Close();
        }
    }
}
