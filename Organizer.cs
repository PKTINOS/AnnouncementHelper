using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstTeitheApplication
{
    public partial class Organizer : Form
    {
        public Organizer()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Organizer_Load(object sender, EventArgs e)
        {
            button6.Text = char.ConvertFromUtf32(button6.Text[0]);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            comboBox1.SelectedIndex = 0;
            int j = 0;
            foreach (Announcement a in Program.Announcements)
            {
                dataGridView1.Rows.Add(new object[] { j,a.category,a.Title, a.publisher.name,a.date.Split('T')[0],a.attachments.Length});
                if (!checkedListBox1.Items.Contains(a.publisher.name))
                    checkedListBox1.Items.Add(a.publisher.name);
                if (!checkedListBox2.Items.Contains(a.category))
                    checkedListBox2.Items.Add(a.category);
                j++;
            }
            dataGridView1.Sort(dataGridView1.Columns["Date"], ListSortDirection.Descending);
            checkedListBox1.Sorted = true;
            checkedListBox2.Sorted = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Announcement a in Program.Announcements)
            {
                if (checkedListBox1.CheckedItems.Contains(a.publisher.name))
                {
                    if (checkedListBox2.CheckedItems.Contains(a.category))
                    {
                        if (comboBox1.Text == "This week")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 7)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                dataGridView1.Rows.Add(new object[] { j, a.category, a.Title, a.publisher.name, a.date.Split('T')[0], a.attachments.Length });
                            }
                        }else if (comboBox1.Text == "This month")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 31)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                dataGridView1.Rows.Add(new object[] { j, a.category, a.Title, a.publisher.name, a.date.Split('T')[0], a.attachments.Length });
                            }
                        }
                        else if (comboBox1.Text == "Last 3 months")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 90)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                dataGridView1.Rows.Add(new object[] { j, a.category, a.Title, a.publisher.name, a.date.Split('T')[0], a.attachments.Length });
                            }
                        }
                        else
                        {
                            int j = Program.Announcements.IndexOf(a);
                            dataGridView1.Rows.Add(new object[] { j, a.category, a.Title, a.publisher.name, a.date.Split('T')[0], a.attachments.Length });
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AnnouncementForm f1 = new AnnouncementForm(Program.Announcements[int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString())]);
                f1.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text;
            temp = Program.ReplaceGreek(temp, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
            textBox1.Text = temp;
            string[] searchValues = temp.Split(',');
            if (searchValues.Length > 0)
            {
                List<Announcement> searchResults = new List<Announcement>();
                if (dataGridView1.Rows.Count - 1 != Program.Announcements.Count && dataGridView1.Rows.Count > 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Αναζήτηση στην τρέχουσα λίστα?", "Διευκρίνηση", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            Announcement curAnnouncement = Program.Announcements[int.Parse(dataGridView1.Rows[i].Cells["ID"].Value.ToString())];
                            foreach (string s in searchValues)
                            {
                                string temptext = Program.ReplaceGreek(curAnnouncement.Text, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                                string temptitle = Program.ReplaceGreek(curAnnouncement.Title, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                                if (temptitle.Contains(s) || temptext.Contains(s))
                                {
                                    searchResults.Add(curAnnouncement);
                                    break;
                                }
                            }
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        foreach (Announcement curAnnouncement in Program.Announcements)
                        {
                            foreach (string s in searchValues)
                            {
                                string temptext = Program.ReplaceGreek(curAnnouncement.Text, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                                string temptitle = Program.ReplaceGreek(curAnnouncement.Title, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                                if (temptitle.Contains(s) || temptext.Contains(s))
                                {
                                    searchResults.Add(curAnnouncement);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Announcement curAnnouncement in Program.Announcements)
                    {
                        foreach (string s in searchValues)
                        {
                            string temptext = Program.ReplaceGreek(curAnnouncement.Text, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                            string temptitle = Program.ReplaceGreek(curAnnouncement.Title, checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
                            if (temptitle.Contains(s) || temptext.Contains(s))
                            {
                                searchResults.Add(curAnnouncement);
                                break;
                            }
                        }
                    }
                }
                dataGridView1.Rows.Clear();
                foreach (Announcement a in searchResults)
                {
                    int j = Program.Announcements.IndexOf(a);
                    dataGridView1.Rows.Add(new object[] { j, a.category, a.Title, a.publisher.name, a.date.Split('T')[0], a.attachments.Length });
                }
            }
        }
    }
}
