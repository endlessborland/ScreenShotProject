using System;
using System.IO;
using System.Windows.Forms;

namespace ScreenShot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Properties.Settings.Default.FirstRun)
            {
                Properties.Settings.Default.path = Environment.GetEnvironmentVariable("TEMP") + "\\ScreenShotTool"; // A path at %TEMP%\ScreenShotTool
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestWindow());
        }
    }
}
