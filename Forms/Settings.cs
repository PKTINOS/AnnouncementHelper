using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnouncementHelper.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Program.StartupEnabled;
        }

        private void Startup_CheckedChanged(object sender, EventArgs e)
        {
            Program.SetStartup(!Program.StartupEnabled);
            Program.StartupEnabled = !Program.StartupEnabled;
        }
    }
}
