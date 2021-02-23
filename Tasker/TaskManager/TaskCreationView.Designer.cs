namespace TaskManager
{
    partial class TaskCreationView 
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
            this.typeBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.nameTb = new MetroFramework.Controls.MetroTextBox();
            this.descriptionTb = new MetroFramework.Controls.MetroTextBox();
            this.submitBtn = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.ItemHeight = 23;
            this.typeBox.Location = new System.Drawing.Point(103, 72);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(137, 29);
            this.typeBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.typeBox.TabIndex = 0;
            this.typeBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 82);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(39, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Type:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 121);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(48, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Name:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(23, 159);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(74, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Description";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(103, 117);
            this.nameTb.Name = "nameTb";
            this.nameTb.PromptText = "Name";
            this.nameTb.Size = new System.Drawing.Size(137, 23);
            this.nameTb.TabIndex = 4;
            this.nameTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // descriptionTb
            // 
            this.descriptionTb.Location = new System.Drawing.Point(103, 155);
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.PromptText = "Description";
            this.descriptionTb.Size = new System.Drawing.Size(137, 23);
            this.descriptionTb.TabIndex = 5;
            this.descriptionTb.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(24, 204);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(216, 38);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Create New";
            this.submitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.submitBtn.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // TaskCreationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 276);
            this.ControlBox = false;
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.descriptionTb);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.typeBox);
            this.Name = "TaskCreationView";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.Flat;
            this.Text = "New Task";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox typeBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox nameTb;
        private MetroFramework.Controls.MetroTextBox descriptionTb;
        private MetroFramework.Controls.MetroTile submitBtn;
    }
}