﻿using System;
using System.Windows.Forms;


namespace Screenshot_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenShot ScreenShot = new ScreenShot(textBox1.Text.ToString()); // With screenshotilka-server, that should be http://10.0.0.1:1234/upload
            ScreenShot.CaptureScreen();
            ScreenShot = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
            {
                this.ShowInTaskbar = false; 
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void makeAScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenShot ScreenShot = new ScreenShot("http://192.168.43.163:4567/upload");
            ScreenShot.CaptureScreen();
            ScreenShot = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
