using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstTeitheApplication
{
    public partial class AnnouncementForm : Form
    {
        private HttpClient client = new HttpClient();
        public AnnouncementForm(Announcement announcement)
        {
            InitializeComponent();
            label1.Text = announcement.Title;
            label2.Text = announcement.date;
            richTextBox1.Text = announcement.Text;
            if (announcement.attachments.Length > 0)
            {
                richTextBox1.Text += Environment.NewLine + Environment.NewLine + "Πρωτα συνδεθειτε στο apps πριν κατεβασετε attachment!!!" + Environment.NewLine + Environment.NewLine;
                richTextBox1.Text += Environment.NewLine + "Attachments:";

                for (int i = 0; i <announcement.attachments.Length;i++)
                richTextBox1.Text += Environment.NewLine + (i+1).ToString() + ":" + "https://apps.it.teithe.gr/api/announcements/" + announcement._id + "/download/" + announcement.attachments[0];
            }
            label4.Text = announcement.publisher.name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AnnouncementForm_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
