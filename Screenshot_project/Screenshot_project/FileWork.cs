using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot_project
{
    static class FileWork
    {
        static private string TEMP = Environment.GetEnvironmentVariable("TEMP"); //путь к %TEMP%
        static DirectoryInfo SavePath = new DirectoryInfo(TEMP + "\\ScreenShotTool"); //директория %TEMP%\ScreenShotTool

        static public void Create_directory()
        {
            if (!SavePath.Exists) //Существует ли директория %TEMP%\ScreenShotTool
                SavePath.Create(); //Если нет - создаем
        }

        static public void SaveScreenShot(ImageFormat format) //сохраняем скриншот экрана 
        {
            Bitmap screenShot = CaptureScreenShot();
            screenShot.Save(Generate_Name(), format);
            screenShot = null; //so the value is no longer in use and can be cleaned up with GC
            GC.Collect(); //cleaning up memory
            GC.WaitForPendingFinalizers();
        }

        static private Bitmap CaptureScreenShot() //делаем скриншот экрана 
        {
            Point MousePoint = new Point(Cursor.Position.X, Cursor.Position.Y); //координаты мыши
            Rectangle bounds = Screen.GetBounds(MousePoint);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                //скриним тот экран, на котором в данный момент находится мышь
            }
            return bitmap;
        }

        static private string Generate_Name() //Генерация имени файла
        {
            int count = SavePath.GetFiles().Count(); //Считаем количество файлов в папке
            return SavePath.FullName + "\\" + (count + 1) + ".jpeg"; //Названием файла будет его порядковый номер
        }
    }
}
