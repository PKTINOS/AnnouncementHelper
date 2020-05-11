using AnnouncementHelper.Tools;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AnnouncementHelper
{
    public partial class AnnouncementForm : Form
    {
        readonly Announcement currentAnnouncement;
        public AnnouncementForm(Announcement announcement)
        {
            InitializeComponent();
            TitleTextbox.Text = announcement.Title;
            DateLabel.Text = announcement.Date;
            DataTextbox.Text = announcement.Text;
            currentAnnouncement = announcement;
            if (announcement.Attachments != null)
            if (announcement.Attachments.Length > 0)
            {
                DataTextbox.Text += Environment.NewLine + Environment.NewLine + "Πρωτα συνδεθειτε στο apps πριν κατεβασετε attachment!!!" + Environment.NewLine + Environment.NewLine;
                DataTextbox.Text += Environment.NewLine + "Attachments:";
                currentAnnouncement.Text += Environment.NewLine + Environment.NewLine + "Πρωτα συνδεθειτε στο apps πριν κατεβασετε attachment!!!" + Environment.NewLine + Environment.NewLine;
                currentAnnouncement.Text += Environment.NewLine + "Attachments:";
                for (int i = 0; i < announcement.Attachments.Length; i++)
                {
                    DataTextbox.Text += Environment.NewLine + (i + 1).ToString() + ":" + "https://apps.it.teithe.gr/api/announcements/" + announcement.AnnouncementHash + "/download/" + announcement.Attachments[0];
                    currentAnnouncement.Text += Environment.NewLine + (i + 1).ToString() + ":" + "https://apps.it.teithe.gr/api/announcements/" + announcement.AnnouncementHash + "/download/" + announcement.Attachments[0];
                }
            }
            PublisherLabel.Text = announcement.Publisher.Name;
            
        }
        private void AnnouncementForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void Data_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void ReminderSet_Click(object sender, EventArgs e)
        {
            string temp = AnnouncementConvert.ToBase64(currentAnnouncement);
    
            string path = Environment.CurrentDirectory + "\\reminder_" + dateTimePicker1.Text+ "T" + temp.Substring(0, 6);
            File.WriteAllText(path,temp);
            if (!Program.StartupEnabled)
            {
                DialogResult dialogResult = MessageBox.Show("Θέλετε να ανοίγει το AnnouncementHelper αυτόματα στην έναρξη για να μην χάνετε τις υπενθυμίσεις (προτεινόμενο)?", "Προσθήκη στην έναρξη?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Program.SetStartup(true);
                }
            }
            MessageBox.Show("Reminder set!", "Message");
        }
    }
}
