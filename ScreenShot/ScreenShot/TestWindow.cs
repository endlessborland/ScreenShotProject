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
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                notificationIcon.Visible = true;
                Hide();
            }
            return;
        }

        private void notificationIcon_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                notificationIcon.Visible = false;
            }
        }

        private async void CaptureScreen()
        {
            Settings.SaveNewSettings(urlinput.Text, path.Text);
            ScreenShot screenshot = new ScreenShot(Properties.Settings.Default.URL, Properties.Settings.Default.port, Properties.Settings.Default.path);
            string response = await screenshot.GetImageDataFromServer();
            if (response != null)
            {
                var response_window = new Answer(Properties.Settings.Default.URL, response, Properties.Settings.Default.port);
                response_window.Show();
            }
            screenshot = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void restoreDefaults_button_Click(object sender, EventArgs e)
        {
            Settings.RestoreDefaults();
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var about = new AboutBox())
            {
                about.ShowDialog();
            }
        }

        private void TestWindow_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
