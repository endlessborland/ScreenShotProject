using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Screenshot_project
{
    public partial class Form1 : Form
    {
        public Form1() //Инициализация формы
        {
            FileWork.Create_directory();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Скриншот!
        {
            FileWork.SaveScreenShot(ImageFormat.Jpeg);            
        }

        private void Form1_Resize(object sender, EventArgs e) //Сворачивание окна
        {
            if (this.WindowState == FormWindowState.Minimized) 
            {
                this.ShowInTaskbar = false; 
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) //Разворачивание окна
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Закрытие программы
        {
            Application.Exit();
        }

        private void makeAScreenshotToolStripMenuItem_Click(object sender, EventArgs e) //Скриншот из трея
        {
            FileWork.SaveScreenShot(ImageFormat.Jpeg);
        }
    }
}
