using System;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class TestWindow : Form
    {
        KeyboardHook hook = new KeyboardHook();

        public TestWindow()
        {
            InitializeComponent();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(ModifierKey.None, Keys.PrintScreen);
            urlinput.Text = Properties.Settings.Default.URL;
            path.Text = Properties.Settings.Default.path;
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            CaptureScreen();
        }

        private void TestWindow_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                Notification_Icon.Visible = true;
            }
        }

        private void Notification_Icon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                Notification_Icon.Visible = false;
            }
        }

        private async void CaptureScreen()
        {
            Properties.Settings.Default.URL = urlinput.Text;
            Properties.Settings.Default.path = path.Text;
            Properties.Settings.Default.Save();
            ScreenShot screenshot = new ScreenShot(Properties.Settings.Default.URL, Properties.Settings.Default.port, Properties.Settings.Default.path);
            string response = await screenshot.GetImageDataFromServer();
            if (response != "No connection")
            {
                var response_window = new Answer(Properties.Settings.Default.URL, response, Properties.Settings.Default.port);
                response_window.Show();
            }
            screenshot = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Screenshot_button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.URL = "192.168.1.6";
            Properties.Settings.Default.port = "4567";
            Properties.Settings.Default.FirstRun = true;
            Properties.Settings.Default.Save();
            urlinput.Text = Properties.Settings.Default.URL;
            path.Text = Properties.Settings.Default.path;
        }

        private void path_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
