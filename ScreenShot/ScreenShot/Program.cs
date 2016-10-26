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
            Settings.CheckFirstLaunch();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestWindow());
        }
    }
}
