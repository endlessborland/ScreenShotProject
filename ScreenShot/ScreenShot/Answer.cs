﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Answer : Form
    {
        public Answer(string url, string filename, string port)
        {
            InitializeComponent();
            var close = new System.Threading.Timer(CloseForm, this, 5000, 5000);
            StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            if (filename != "No data availible")
            {
                var completeurl = "http://" + url + ":" + port + "/";
                URL.Text = completeurl + filename;
                Clipboard.SetText(URL.Text);
            }
            else
                URL.Text = filename;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CloseForm(object o)
        {
            Close();
        }
    }
}
