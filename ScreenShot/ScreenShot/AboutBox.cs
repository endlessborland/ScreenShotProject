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
