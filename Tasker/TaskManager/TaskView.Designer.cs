namespace TaskManager
{
    partial class TaskView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usersPanel = new MetroFramework.Controls.MetroPanel();
            this.respondersPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.removeFromBtn = new MetroFramework.Controls.MetroTile();
            this.showTasksBtn = new MetroFramework.Controls.MetroTile();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.descriptionTb = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // usersPanel
            // 
            this.usersPanel.AutoScroll = true;
            this.usersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.usersPanel.CustomBackground = true;
            this.usersPanel.HorizontalScrollbar = true;
            this.usersPanel.HorizontalScrollbarBarColor = true;
            this.usersPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.usersPanel.HorizontalScrollbarSize = 10;
            this.usersPanel.Location = new System.Drawing.Point(589, 97);
            this.usersPanel.Name = "usersPanel";
            this.usersPanel.Size = new System.Drawing.Size(209, 257);
            this.usersPanel.TabIndex = 0;
            this.usersPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usersPanel.VerticalScrollbar = true;
            this.usersPanel.VerticalScrollbarBarColor = true;
            this.usersPanel.VerticalScrollbarHighlightOnWheel = false;
            this.usersPanel.VerticalScrollbarSize = 10;
            // 
            // respondersPanel
            // 
            this.respondersPanel.AutoScroll = true;
            this.respondersPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.respondersPanel.CustomBackground = true;
            this.respondersPanel.HorizontalScrollbar = true;
            this.respondersPanel.HorizontalScrollbarBarColor = true;
            this.respondersPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.respondersPanel.HorizontalScrollbarSize = 10;
            this.respondersPanel.Location = new System.Drawing.Point(358, 97);
            this.respondersPanel.Name = "respondersPanel";
            this.respondersPanel.Size = new System.Drawing.Size(209, 257);
            this.respondersPanel.TabIndex = 1;
            this.respondersPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.respondersPanel.VerticalScrollbar = true;
            this.respondersPanel.VerticalScrollbarBarColor = true;
            this.respondersPanel.VerticalScrollbarHighlightOnWheel = false;
            this.respondersPanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(413, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(100, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Responders";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(655, 60);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "All Users";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // removeFromBtn
            // 
            this.removeFromBtn.Location = new System.Drawing.Point(13, 308);
            this.removeFromBtn.Name = "removeFromBtn";
            this.removeFromBtn.Size = new System.Drawing.Size(147, 49);
            this.removeFromBtn.Style = MetroFramework.MetroColorStyle.Red;
            this.removeFromBtn.TabIndex = 6;
            this.removeFromBtn.Text = "Remove";
            this.removeFromBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.removeFromBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.removeFromBtn.Click += new System.EventHandler(this.removeFromBtn_Click);
            // 
            // showTasksBtn
            // 
            this.showTasksBtn.Location = new System.Drawing.Point(182, 308);
            this.showTasksBtn.Name = "showTasksBtn";
            this.showTasksBtn.Size = new System.Drawing.Size(151, 49);
            this.showTasksBtn.TabIndex = 7;
            this.showTasksBtn.Text = "Show Tasks";
            this.showTasksBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showTasksBtn.Click += new System.EventHandler(this.showTasksBtn_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(13, 97);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(77, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Description:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // descriptionTb
            // 
            this.descriptionTb.Location = new System.Drawing.Point(97, 97);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.ReadOnly = true;
            this.descriptionTb.Size = new System.Drawing.Size(236, 194);
            this.descriptionTb.TabIndex = 9;
            this.descriptionTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // TaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 380);
            this.Controls.Add(this.descriptionTb);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.showTasksBtn);
            this.Controls.Add(this.removeFromBtn);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.respondersPanel);
            this.Controls.Add(this.usersPanel);
            this.Name = "TaskView";
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Task";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel usersPanel;
        private MetroFramework.Controls.MetroPanel respondersPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile removeFromBtn;
        private MetroFramework.Controls.MetroTile showTasksBtn;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox descriptionTb;
    }
}