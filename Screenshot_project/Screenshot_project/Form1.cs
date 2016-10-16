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
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveScreenShot(string filename, ImageFormat format) // сохраняем скриншот экрана 
        {
            Bitmap screenShot = CaptureScreenShot();
            screenShot.Save(filename, format);
            screenShot = null; //so the value is no longer in use and can be cleaned up with GC
        }

        private Bitmap CaptureScreenShot() // делаем скриншот экрана 
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics gr = Graphics.FromImage(bitmap))
            { gr.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size); }

            return bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveScreenShot("D:\\Desktop\\screenshot_project\\Screenshot1.jpeg", ImageFormat.Jpeg);
            GC.Collect(); //cleaning up memory
            GC.WaitForPendingFinalizers(); 
            
        }
    }
}
