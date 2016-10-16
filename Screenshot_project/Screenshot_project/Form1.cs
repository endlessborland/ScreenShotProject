using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Screenshot_project
{
    public partial class Form1 : Form
    {
        public const int FILENAME_LENGTH = 15;

        private string path = "D:\\Desktop\\screenshot_project\\";
        private static Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveScreenShot(string filename, ImageFormat format) // сохраняем скриншот экрана 
        {
            Bitmap screenShot = CaptureScreenShot();
            screenShot.Save(filename, format); //i feel like there are some exceptions needed here
            screenShot = null; //so the value is no longer in use and can be cleaned up with GC
        }

        private Bitmap CaptureScreenShot() // делаем скриншот экрана 
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

        /*private string Generate_Name()
        {
            generate name somehow
            
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            SaveScreenShot("D:\\Desktop\\screenshot_project\\Screenshot1.jpeg", ImageFormat.Jpeg);
            //SaveScreenShot(path + Generate_Name(), ImageFormat.Jpeg);
            GC.Collect(); //cleaning up memory
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

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}
