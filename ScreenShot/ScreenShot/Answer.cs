using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class Answer : Form
    {
        public Answer(string url, string filename)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
            if (filename != "No data availible")
            {
                URL.Text = url.Replace("/upload", "/") + filename;
                Clipboard.SetText(URL.Text);
            }
            else
                URL.Text = filename;
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
