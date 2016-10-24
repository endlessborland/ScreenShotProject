using System;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class TestWindow : Form
    {
        KeyboardHook hook = new KeyboardHook();

        private string URL = "http://192.168.1.151:4567/upload";

        public TestWindow()
        {
            InitializeComponent();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(ModifierKey.None, Keys.PrintScreen);
            url_input.Text = URL;

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
            ScreenShot screenshot = new ScreenShot(url_input.Text);
            string response = await screenshot.GetImageDataFromServer();
            if (response != "No connection")
            {
                var response_window = new Answer(url_input.Text, response);
                response_window.Show();
            }
            screenshot = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Screenshot_button_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }
    }
}
