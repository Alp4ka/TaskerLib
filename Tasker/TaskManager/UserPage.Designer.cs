namespace TaskManager
{
    partial class UserPage
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
            this.userNameLabel = new MetroFramework.Controls.MetroLabel();
            this.userSurnameLabel = new MetroFramework.Controls.MetroLabel();
            this.userIdLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.userRankLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(100, 114);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(81, 19);
            this.userNameLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "metroLabel1";
            this.userNameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // userSurnameLabel
            // 
            this.userSurnameLabel.AutoSize = true;
            this.userSurnameLabel.Location = new System.Drawing.Point(100, 152);
            this.userSurnameLabel.Name = "userSurnameLabel";
            this.userSurnameLabel.Size = new System.Drawing.Size(81, 19);
            this.userSurnameLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.userSurnameLabel.TabIndex = 1;
            this.userSurnameLabel.Text = "metroLabel1";
            this.userSurnameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(100, 80);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(81, 19);
            this.userIdLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.userIdLabel.TabIndex = 2;
            this.userIdLabel.Text = "metroLabel1";
            this.userIdLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(46, 114);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(48, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Name:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(30, 152);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(64, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Surname:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(70, 80);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(24, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "ID:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(54, 188);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(40, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Rank:";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // userRankLabel
            // 
            this.userRankLabel.AutoSize = true;
            this.userRankLabel.Location = new System.Drawing.Point(100, 188);
            this.userRankLabel.Name = "userRankLabel";
            this.userRankLabel.Size = new System.Drawing.Size(81, 19);
            this.userRankLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.userRankLabel.TabIndex = 7;
            this.userRankLabel.Text = "metroLabel1";
            this.userRankLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(360, 218);
            this.Controls.Add(this.userRankLabel);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.userSurnameLabel);
            this.Controls.Add(this.userNameLabel);
            this.Name = "UserPage";
            this.Opacity = 0.93D;
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.Flat;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Text = "UserPage";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MetroFramework.Controls.MetroLabel userNameLabel;
        public MetroFramework.Controls.MetroLabel userSurnameLabel;
        public MetroFramework.Controls.MetroLabel userIdLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroLabel userRankLabel;
    }
}