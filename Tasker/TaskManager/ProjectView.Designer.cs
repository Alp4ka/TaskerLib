namespace TaskManager
{
    partial class ProjectView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectView));
            this.openPanel = new MetroFramework.Controls.MetroPanel();
            this.progressPanel = new MetroFramework.Controls.MetroPanel();
            this.closedPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.rollUpButton = new MetroFramework.Controls.MetroTile();
            this.controlExitButton = new MetroFramework.Controls.MetroTile();
            this.addOpenTaskTile = new MetroFramework.Controls.MetroTile();
            this.addProgressTaskTile = new MetroFramework.Controls.MetroTile();
            this.addClosedTaskTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // openPanel
            // 
            resources.ApplyResources(this.openPanel, "openPanel");
            this.openPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.openPanel.CustomBackground = true;
            this.openPanel.HorizontalScrollbar = true;
            this.openPanel.HorizontalScrollbarBarColor = true;
            this.openPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.openPanel.HorizontalScrollbarSize = 10;
            this.openPanel.Name = "openPanel";
            this.openPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.openPanel.VerticalScrollbar = true;
            this.openPanel.VerticalScrollbarBarColor = true;
            this.openPanel.VerticalScrollbarHighlightOnWheel = false;
            this.openPanel.VerticalScrollbarSize = 10;
            // 
            // progressPanel
            // 
            resources.ApplyResources(this.progressPanel, "progressPanel");
            this.progressPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.progressPanel.CustomBackground = true;
            this.progressPanel.HorizontalScrollbar = true;
            this.progressPanel.HorizontalScrollbarBarColor = true;
            this.progressPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.progressPanel.HorizontalScrollbarSize = 10;
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressPanel.VerticalScrollbar = true;
            this.progressPanel.VerticalScrollbarBarColor = true;
            this.progressPanel.VerticalScrollbarHighlightOnWheel = false;
            this.progressPanel.VerticalScrollbarSize = 10;
            // 
            // closedPanel
            // 
            resources.ApplyResources(this.closedPanel, "closedPanel");
            this.closedPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.closedPanel.CustomBackground = true;
            this.closedPanel.HorizontalScrollbar = true;
            this.closedPanel.HorizontalScrollbarBarColor = true;
            this.closedPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.closedPanel.HorizontalScrollbarSize = 10;
            this.closedPanel.Name = "closedPanel";
            this.closedPanel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.closedPanel.VerticalScrollbar = true;
            this.closedPanel.VerticalScrollbarBarColor = true;
            this.closedPanel.VerticalScrollbarHighlightOnWheel = false;
            this.closedPanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = MetroFramework.MetroColorStyle.Green;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // rollUpButton
            // 
            resources.ApplyResources(this.rollUpButton, "rollUpButton");
            this.rollUpButton.Name = "rollUpButton";
            this.rollUpButton.Style = MetroFramework.MetroColorStyle.Yellow;
            this.rollUpButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.rollUpButton.Click += new System.EventHandler(this.rollUpButton_Click);
            // 
            // controlExitButton
            // 
            resources.ApplyResources(this.controlExitButton, "controlExitButton");
            this.controlExitButton.Name = "controlExitButton";
            this.controlExitButton.Style = MetroFramework.MetroColorStyle.Red;
            this.controlExitButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.controlExitButton.Click += new System.EventHandler(this.controlExitButton_Click);
            // 
            // addOpenTaskTile
            // 
            resources.ApplyResources(this.addOpenTaskTile, "addOpenTaskTile");
            this.addOpenTaskTile.Name = "addOpenTaskTile";
            this.addOpenTaskTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.addOpenTaskTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addOpenTaskTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.addOpenTaskTile.Click += new System.EventHandler(this.addTaskButtonClick);
            // 
            // addProgressTaskTile
            // 
            resources.ApplyResources(this.addProgressTaskTile, "addProgressTaskTile");
            this.addProgressTaskTile.Name = "addProgressTaskTile";
            this.addProgressTaskTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.addProgressTaskTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addProgressTaskTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.addProgressTaskTile.Click += new System.EventHandler(this.addTaskButtonClick);
            // 
            // addClosedTaskTile
            // 
            resources.ApplyResources(this.addClosedTaskTile, "addClosedTaskTile");
            this.addClosedTaskTile.Name = "addClosedTaskTile";
            this.addClosedTaskTile.Style = MetroFramework.MetroColorStyle.Silver;
            this.addClosedTaskTile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addClosedTaskTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.addClosedTaskTile.Click += new System.EventHandler(this.addTaskButtonClick);
            // 
            // ProjectView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.addClosedTaskTile);
            this.Controls.Add(this.addProgressTaskTile);
            this.Controls.Add(this.addOpenTaskTile);
            this.Controls.Add(this.rollUpButton);
            this.Controls.Add(this.controlExitButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.closedPanel);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.openPanel);
            this.Name = "ProjectView";
            this.Opacity = 0.98D;
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel openPanel;
        private MetroFramework.Controls.MetroPanel progressPanel;
        private MetroFramework.Controls.MetroPanel closedPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroTile rollUpButton;
        private MetroFramework.Controls.MetroTile controlExitButton;
        private MetroFramework.Controls.MetroTile addOpenTaskTile;
        private MetroFramework.Controls.MetroTile addProgressTaskTile;
        private MetroFramework.Controls.MetroTile addClosedTaskTile;
    }
}