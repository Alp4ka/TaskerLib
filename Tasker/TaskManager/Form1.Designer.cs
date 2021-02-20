namespace TaskManager
{
    partial class Form1
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.AutoScroll = true;
            this.metroPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroPanel1.Controls.Add(this.metroTile2);
            this.metroPanel1.Controls.Add(this.metroTile1);
            this.metroPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroPanel1.CustomBackground = true;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(250, 370);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbar = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTile2
            // 
            this.metroTile2.BackColor = System.Drawing.Color.DarkOrange;
            this.metroTile2.CustomBackground = true;
            this.metroTile2.Location = new System.Drawing.Point(35, 85);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(182, 39);
            this.metroTile2.TabIndex = 3;
            this.metroTile2.Text = "РЫБА";
            this.metroTile2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseDown);
            this.metroTile2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseMove);
            this.metroTile2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseUp);
            // 
            // metroTile1
            // 
            this.metroTile1.BackColor = System.Drawing.Color.DarkOrange;
            this.metroTile1.Cursor = System.Windows.Forms.Cursors.Default;
            this.metroTile1.CustomBackground = true;
            this.metroTile1.Location = new System.Drawing.Point(35, 21);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(182, 39);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "МЯСО";
            this.metroTile1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseDown);
            this.metroTile1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseMove);
            this.metroTile1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroTile1_MouseUp);
            // 
            // metroPanel2
            // 
            this.metroPanel2.AutoScroll = true;
            this.metroPanel2.BackColor = System.Drawing.Color.DarkGray;
            this.metroPanel2.CustomBackground = true;
            this.metroPanel2.HorizontalScrollbar = true;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(527, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(250, 370);
            this.metroPanel2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbar = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Form1";
            this.Text = "DragNDrop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
    }
}

