using System;
using System.Windows.Forms;

namespace AnnouncementHelper
{
    public partial class AnnouncementForm : Form
    {
        public AnnouncementForm(Announcement announcement)
        {
            InitializeComponent();
            TitleTextbox.Text = announcement.Title;
            DateLabel.Text = announcement.Date;
            DataTextbox.Text = announcement.Text;
            if (announcement.Attachments.Length > 0)
            {
                DataTextbox.Text += Environment.NewLine + Environment.NewLine + "Πρωτα συνδεθειτε στο apps πριν κατεβασετε attachment!!!" + Environment.NewLine + Environment.NewLine;
                DataTextbox.Text += Environment.NewLine + "Attachments:";

                for (int i = 0; i < announcement.Attachments.Length;i++)
                DataTextbox.Text += Environment.NewLine + (i+1).ToString() + ":" + "https://apps.it.teithe.gr/api/announcements/" + announcement.AnnouncementHash + "/download/" + announcement.Attachments[0];
            }
            PublisherLabel.Text = announcement.Publisher.Name;
        }
        private void AnnouncementForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void Data_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
