using System;

namespace ScreenShot
{
    public class Settings
    {

        /// <summary>
        /// Restores Defaults
        /// </summary>
        static public void RestoreDefaults()
        {
            Properties.Settings.Default.URL = "80.240.212.66";
            Properties.Settings.Default.port = "4567";
            Properties.Settings.Default.FirstLaunch = true;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Sets initial saving path
        /// </summary>
        static public void CheckFirstLaunch()
        {
            if (Properties.Settings.Default.FirstLaunch)
            {
                Properties.Settings.Default.path = Environment.GetEnvironmentVariable("TEMP") + "\\ScreenShotTool"; // A path at %TEMP%\ScreenShotTool
                Properties.Settings.Default.FirstLaunch = false;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Saves settings after modification
        /// </summary>
        /// <param name="url">Server URL</param>
        /// <param name="path">Local path</param>
        static public void SaveNewSettings(string url, string path, string port)
        {
            Properties.Settings.Default.URL = url;
            Properties.Settings.Default.path = path;
            Properties.Settings.Default.port = port;
            Properties.Settings.Default.Save();
        }
    }
}
