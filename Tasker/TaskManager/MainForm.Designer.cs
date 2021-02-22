namespace TaskManager
{
    partial class MainForm: MetroFramework.Forms.MetroForm
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
            this.menuPage = new MetroFramework.Controls.MetroTabPage();
            this.exitButton = new MetroFramework.Controls.MetroTile();
            this.usersButton = new MetroFramework.Controls.MetroTile();
            this.projectsButton = new MetroFramework.Controls.MetroTile();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.projectsPage = new MetroFramework.Controls.MetroTabPage();
            this.usersPage = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.usersPanel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.warningLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.newUserSurnameTb = new MetroFramework.Controls.MetroTextBox();
            this.newUserNameTb = new MetroFramework.Controls.MetroTextBox();
            this.createNewUserButton = new MetroFramework.Controls.MetroTile();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.warningProj = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.newProjectDescrTb = new MetroFramework.Controls.MetroTextBox();
            this.newProjectNameTb = new MetroFramework.Controls.MetroTextBox();
            this.newProjectButton = new MetroFramework.Controls.MetroTile();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.projectsPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.controlExitButton = new MetroFramework.Controls.MetroTile();
            this.rollUpButton = new MetroFramework.Controls.MetroTile();
            this.menuPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.projectsPage.SuspendLayout();
            this.usersPage.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPage
            // 
            this.menuPage.BackColor = System.Drawing.Color.Maroon;
            this.menuPage.Controls.Add(this.metroLabel7);
            this.menuPage.Controls.Add(this.exitButton);
            this.menuPage.Controls.Add(this.usersButton);
            this.menuPage.Controls.Add(this.projectsButton);
            this.menuPage.HorizontalScrollbarBarColor = true;
            this.menuPage.Location = new System.Drawing.Point(4, 35);
            this.menuPage.Name = "menuPage";
            this.menuPage.Size = new System.Drawing.Size(791, 348);
            this.menuPage.TabIndex = 0;
            this.menuPage.Text = "Menu";
            this.menuPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.menuPage.VerticalScrollbarBarColor = true;
            // 
            // exitButton
            // 
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitButton.Location = new System.Drawing.Point(513, 104);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(260, 95);
            this.exitButton.Style = MetroFramework.MetroColorStyle.Red;
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Location = new System.Drawing.Point(266, 104);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(241, 95);
            this.usersButton.TabIndex = 3;
            this.usersButton.Text = "Users";
            this.usersButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // projectsButton
            // 
            this.projectsButton.Location = new System.Drawing.Point(19, 104);
            this.projectsButton.Name = "projectsButton";
            this.projectsButton.Size = new System.Drawing.Size(241, 95);
            this.projectsButton.TabIndex = 2;
            this.projectsButton.Text = "Projects";
            this.projectsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.projectsButton.Click += new System.EventHandler(this.projectsButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.menuPage);
            this.tabControl.Controls.Add(this.projectsPage);
            this.tabControl.Controls.Add(this.usersPage);
            this.tabControl.Location = new System.Drawing.Point(0, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(799, 387);
            this.tabControl.TabIndex = 0;
            this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.UseStyleColors = true;
            // 
            // projectsPage
            // 
            this.projectsPage.Controls.Add(this.metroLabel3);
            this.projectsPage.Controls.Add(this.projectsPanel);
            this.projectsPage.Controls.Add(this.metroPanel2);
            this.projectsPage.HorizontalScrollbarBarColor = true;
            this.projectsPage.Location = new System.Drawing.Point(4, 35);
            this.projectsPage.Name = "projectsPage";
            this.projectsPage.Size = new System.Drawing.Size(791, 348);
            this.projectsPage.Style = MetroFramework.MetroColorStyle.Blue;
            this.projectsPage.TabIndex = 1;
            this.projectsPage.Text = "Projects";
            this.projectsPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.projectsPage.VerticalScrollbar = true;
            this.projectsPage.VerticalScrollbarBarColor = true;
            // 
            // usersPage
            // 
            this.usersPage.Controls.Add(this.metroLabel4);
            this.usersPage.Controls.Add(this.usersPanel);
            this.usersPage.Controls.Add(this.metroPanel1);
            this.usersPage.HorizontalScrollbarBarColor = true;
            this.usersPage.Location = new System.Drawing.Point(4, 35);
            this.usersPage.Name = "usersPage";
            this.usersPage.Size = new System.Drawing.Size(791, 348);
            this.usersPage.TabIndex = 2;
            this.usersPage.Text = "Users";
            this.usersPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usersPage.VerticalScrollbarBarColor = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.Location = new System.Drawing.Point(253, 9);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(53, 25);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Users";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // usersPanel
            // 
            this.usersPanel.AutoScroll = true;
            this.usersPanel.HorizontalScrollbar = true;
            this.usersPanel.HorizontalScrollbarBarColor = true;
            this.usersPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.usersPanel.HorizontalScrollbarSize = 10;
            this.usersPanel.Location = new System.Drawing.Point(253, 46);
            this.usersPanel.Name = "usersPanel";
            this.usersPanel.Size = new System.Drawing.Size(504, 299);
            this.usersPanel.Style = MetroFramework.MetroColorStyle.Blue;
            this.usersPanel.TabIndex = 3;
            this.usersPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usersPanel.VerticalScrollbar = true;
            this.usersPanel.VerticalScrollbarBarColor = true;
            this.usersPanel.VerticalScrollbarHighlightOnWheel = true;
            this.usersPanel.VerticalScrollbarSize = 10;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.warningLabel);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.newUserSurnameTb);
            this.metroPanel1.Controls.Add(this.newUserNameTb);
            this.metroPanel1.Controls.Add(this.createNewUserButton);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 15);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(215, 151);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPanel1.TabIndex = 2;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Location = new System.Drawing.Point(3, 0);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(83, 19);
            this.warningLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.warningLabel.TabIndex = 7;
            this.warningLabel.Text = "metroLabel3";
            this.warningLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.warningLabel.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 35);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Name";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 73);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(61, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Surname";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newUserSurnameTb
            // 
            this.newUserSurnameTb.Location = new System.Drawing.Point(66, 69);
            this.newUserSurnameTb.Name = "newUserSurnameTb";
            this.newUserSurnameTb.PromptText = "Surname";
            this.newUserSurnameTb.Size = new System.Drawing.Size(149, 23);
            this.newUserSurnameTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.newUserSurnameTb.TabIndex = 4;
            this.newUserSurnameTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newUserNameTb
            // 
            this.newUserNameTb.Location = new System.Drawing.Point(66, 31);
            this.newUserNameTb.Name = "newUserNameTb";
            this.newUserNameTb.PromptText = "Name";
            this.newUserNameTb.Size = new System.Drawing.Size(149, 23);
            this.newUserNameTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.newUserNameTb.TabIndex = 3;
            this.newUserNameTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // createNewUserButton
            // 
            this.createNewUserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.createNewUserButton.Location = new System.Drawing.Point(0, 108);
            this.createNewUserButton.Name = "createNewUserButton";
            this.createNewUserButton.Size = new System.Drawing.Size(215, 43);
            this.createNewUserButton.TabIndex = 2;
            this.createNewUserButton.Text = "Create New";
            this.createNewUserButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.createNewUserButton.Click += new System.EventHandler(this.createNewUserButton_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.warningProj);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.newProjectDescrTb);
            this.metroPanel2.Controls.Add(this.newProjectNameTb);
            this.metroPanel2.Controls.Add(this.newProjectButton);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 15);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(215, 151);
            this.metroPanel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroPanel2.TabIndex = 3;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // warningProj
            // 
            this.warningProj.AutoSize = true;
            this.warningProj.Location = new System.Drawing.Point(3, 0);
            this.warningProj.Name = "warningProj";
            this.warningProj.Size = new System.Drawing.Size(83, 19);
            this.warningProj.Style = MetroFramework.MetroColorStyle.Blue;
            this.warningProj.TabIndex = 7;
            this.warningProj.Text = "metroLabel3";
            this.warningProj.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.warningProj.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(3, 35);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(45, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "Name";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 73);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(74, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel6.TabIndex = 5;
            this.metroLabel6.Text = "Description";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newProjectDescrTb
            // 
            this.newProjectDescrTb.Location = new System.Drawing.Point(83, 69);
            this.newProjectDescrTb.Name = "newProjectDescrTb";
            this.newProjectDescrTb.PromptText = "Description";
            this.newProjectDescrTb.Size = new System.Drawing.Size(132, 23);
            this.newProjectDescrTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.newProjectDescrTb.TabIndex = 4;
            this.newProjectDescrTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newProjectNameTb
            // 
            this.newProjectNameTb.Location = new System.Drawing.Point(66, 31);
            this.newProjectNameTb.Name = "newProjectNameTb";
            this.newProjectNameTb.PromptText = "Name";
            this.newProjectNameTb.Size = new System.Drawing.Size(149, 23);
            this.newProjectNameTb.Style = MetroFramework.MetroColorStyle.Blue;
            this.newProjectNameTb.TabIndex = 3;
            this.newProjectNameTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // newProjectButton
            // 
            this.newProjectButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newProjectButton.Location = new System.Drawing.Point(0, 108);
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(215, 43);
            this.newProjectButton.TabIndex = 2;
            this.newProjectButton.Text = "Create New";
            this.newProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(253, 9);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(71, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Projects";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // projectsPanel
            // 
            this.projectsPanel.AutoScroll = true;
            this.projectsPanel.HorizontalScrollbar = true;
            this.projectsPanel.HorizontalScrollbarBarColor = true;
            this.projectsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.projectsPanel.HorizontalScrollbarSize = 10;
            this.projectsPanel.Location = new System.Drawing.Point(253, 46);
            this.projectsPanel.Name = "projectsPanel";
            this.projectsPanel.Size = new System.Drawing.Size(504, 299);
            this.projectsPanel.Style = MetroFramework.MetroColorStyle.Blue;
            this.projectsPanel.TabIndex = 5;
            this.projectsPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.projectsPanel.VerticalScrollbar = true;
            this.projectsPanel.VerticalScrollbarBarColor = true;
            this.projectsPanel.VerticalScrollbarHighlightOnWheel = true;
            this.projectsPanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.Location = new System.Drawing.Point(364, 43);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(56, 25);
            this.metroLabel7.TabIndex = 5;
            this.metroLabel7.Text = "Menu";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // controlExitButton
            // 
            this.controlExitButton.Location = new System.Drawing.Point(779, 10);
            this.controlExitButton.Name = "controlExitButton";
            this.controlExitButton.Size = new System.Drawing.Size(15, 15);
            this.controlExitButton.Style = MetroFramework.MetroColorStyle.Red;
            this.controlExitButton.TabIndex = 1;
            this.controlExitButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.controlExitButton.Click += new System.EventHandler(this.controlExitButton_Click);
            // 
            // rollUpButton
            // 
            this.rollUpButton.Location = new System.Drawing.Point(758, 10);
            this.rollUpButton.Name = "rollUpButton";
            this.rollUpButton.Size = new System.Drawing.Size(15, 15);
            this.rollUpButton.Style = MetroFramework.MetroColorStyle.Yellow;
            this.rollUpButton.TabIndex = 2;
            this.rollUpButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rollUpButton.Click += new System.EventHandler(this.rollUpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.exitButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.rollUpButton);
            this.Controls.Add(this.controlExitButton);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.Flat;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "Trello Killer";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuPage.ResumeLayout(false);
            this.menuPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.projectsPage.ResumeLayout(false);
            this.projectsPage.PerformLayout();
            this.usersPage.ResumeLayout(false);
            this.usersPage.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabPage menuPage;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTile projectsButton;
        private MetroFramework.Controls.MetroTabPage projectsPage;
        private MetroFramework.Controls.MetroTile exitButton;
        private MetroFramework.Controls.MetroTile usersButton;
        private MetroFramework.Controls.MetroTabPage usersPage;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox newUserNameTb;
        private MetroFramework.Controls.MetroTile createNewUserButton;
        private MetroFramework.Controls.MetroTextBox newUserSurnameTb;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel warningLabel;
        private MetroFramework.Controls.MetroPanel usersPanel;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel warningProj;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox newProjectDescrTb;
        private MetroFramework.Controls.MetroTextBox newProjectNameTb;
        private MetroFramework.Controls.MetroTile newProjectButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroPanel projectsPanel;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTile controlExitButton;
        private MetroFramework.Controls.MetroTile rollUpButton;
    }
}