using AnnouncementHelper.Tools;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnnouncementHelper.Forms
{
    public partial class Settings : Form
    {
        Panel[] panels;
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            panels = new Panel[]
            {
                StartupPanel,
                RemindersPanel,
                CustomizationPanel
            };
            SettingsList.SelectedIndex = 0;
            pictureBox1.BackColor = Program.BgColor;
            checkBox1.CheckedChanged -= Startup_CheckedChanged;
            checkBox1.Checked = Program.StartupEnabled;
            checkBox1.CheckedChanged += Startup_CheckedChanged;
        }

        private void Startup_CheckedChanged(object sender, EventArgs e)
        {
            Program.SetStartup(!Program.StartupEnabled);
            Program.StartupEnabled = !Program.StartupEnabled;
        }
        private void SettingsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel curPanel = null;
            foreach (Panel p in panels)
            {
                if (p.Name.ToLower().Contains(SettingsList.SelectedItem.ToString().ToLower()))
                    curPanel = p;
                p.Visible = false;
            }
            if (curPanel != null)
            {
                curPanel.Visible = true;
                curPanel.Location = new Point(120, 0);
                curPanel.Size = new Size(295, 446);
            }
        }

        private void BgColorButton_Click(object sender, EventArgs e)
        {
            if (ColorPick.ShowDialog() == DialogResult.OK)
            {
                Program.BgColor = ColorPick.Color;
                pictureBox1.BackColor = Program.BgColor;
            }
            SettingsManager.ChangeSetting(SettingsManager.ColorToString(Program.BgColor), "Color");
        }
    }
}
