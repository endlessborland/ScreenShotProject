using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            versionNumber.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
