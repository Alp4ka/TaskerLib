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

namespace TaskManager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            RecalculateAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool click = false;
        Color _originalColor;
        private void metroTile1_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
            _originalColor = Color.FromArgb((sender as MetroTile).BackColor.R, 
                                            (sender as MetroTile).BackColor.G,
                                            (sender as MetroTile).BackColor.B);
        }


        private void RecalculateChildren(MetroPanel mpanel, int distance=20)
        {
            MetroTile[] children = mpanel.Controls.OfType<MetroTile>().ToArray();
            for(int i =0; i < children.Length; ++i)
            {
                children[i].Location = new Point((mpanel.Width - children[i].Width) / 2,
                                                distance*(i+1) + i*children[i].Height);
            }
        }
        private void RecalculateAll()
        {
            foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
            {
                RecalculateChildren(panel);
            }
        }
        private void metroTile1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            if (click)
            {
                foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
                {
                    panel.BackColor = Color.DarkGray;
                }
                foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
                {
                    if (panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                    {
                        (sender as MetroTile).Parent = panel;
                        (sender as MetroTile).BackColor = _originalColor;
                        RecalculateAll();
                        click = false;
                        return;
                    }

                }

            }
            (sender as MetroTile).BackColor = _originalColor;
            click = false;
        }

        private void metroTile1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (click)
            {
                foreach (var panel in Controls.OfType<MetroPanel>().ToArray())
                {
                    if (panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)) &&
                        panel != (sender as MetroTile).Parent)
                    {
                        panel.BackColor = Color.LightGray;
                    }
                    else
                    {
                        panel.BackColor = Color.DarkGray;
                    }
                }
                (sender as MetroTile).BackColor = Color.FromArgb((_originalColor.R+50) > 255 ? 255: (_originalColor.R + 50),
                                                                (_originalColor.G + 50) > 255 ? 255 : (_originalColor.G + 50),
                                                                (_originalColor.B + 50) > 255 ? 255 : (_originalColor.B + 50));
                Cursor = Cursors.Hand;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
