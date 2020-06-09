using AnnouncementHelper.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace AnnouncementHelper
{
    public partial class Organizer : Form
    {
        public Organizer()
        {
            InitializeComponent();
        }
        private void Organizer_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            ShowInTaskbar = true;
            Text += " " + Program.VERSION;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            SearchButton.Text = char.ConvertFromUtf32(SearchButton.Text[0]);
            DateSelectBox.SelectedIndex = 0;

            int j = 0;
            foreach (Announcement a in Program.Announcements)
            {
                AnnouncementGridView.Rows.Add(new object[] { j,a.Category,a.Title, a.Publisher.Name,a.Date.Split('T')[0],a.Attachments.Length});
                if (!PublisherListbox.Items.Contains(a.Publisher.Name))
                    PublisherListbox.Items.Add(a.Publisher.Name);
                if (!CategoryListbox.Items.Contains(a.Category))
                    CategoryListbox.Items.Add(a.Category);
                j++;
            }
            AnnouncementGridView.Sort(AnnouncementGridView.Columns["Date"], ListSortDirection.Descending);
            PublisherListbox.Sorted = true;
            CategoryListbox.Sorted = true;
            for (int i = 0; i < PublisherListbox.Items.Count; i++)
            {
                PublisherListbox.SetItemChecked(i, true);
            }
            for (int i = 0; i < CategoryListbox.Items.Count; i++)
            {
                CategoryListbox.SetItemChecked(i, true);
            }
        }
        private void SelectAllPublisher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PublisherListbox.Items.Count; i++)
            {
                PublisherListbox.SetItemChecked(i, true);
            }
        }

        private void UnselectAllPublisher_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PublisherListbox.Items.Count; i++)
            {
                PublisherListbox.SetItemChecked(i, false);
            }
        }
        private void ShowAnnouncements_Click(object sender, EventArgs e)
        {
            AnnouncementGridView.Rows.Clear();
            foreach (Announcement a in Program.Announcements)
            {
                if (PublisherListbox.CheckedItems.Contains(a.Publisher.Name))
                {
                    if (CategoryListbox.CheckedItems.Contains(a.Category))
                    {
                        if (DateSelectBox.Text == "This week")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.Date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 7)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                AnnouncementGridView.Rows.Add(new object[] { j, a.Category, a.Title, a.Publisher.Name, a.Date.Split('T')[0], a.Attachments.Length });
                            }
                        }else if (DateSelectBox.Text == "This month")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.Date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 31)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                AnnouncementGridView.Rows.Add(new object[] { j, a.Category, a.Title, a.Publisher.Name, a.Date.Split('T')[0], a.Attachments.Length });
                            }
                        }
                        else if (DateSelectBox.Text == "Last 3 months")
                        {
                            if ((DateTime.Today - DateTime.ParseExact(a.Date.Split('T')[0], "yyyy-MM-dd", CultureInfo.InvariantCulture)).Days <= 90)
                            {
                                int j = Program.Announcements.IndexOf(a);
                                AnnouncementGridView.Rows.Add(new object[] { j, a.Category, a.Title, a.Publisher.Name, a.Date.Split('T')[0], a.Attachments.Length });
                            }
                        }
                        else
                        {
                            int j = Program.Announcements.IndexOf(a);
                            AnnouncementGridView.Rows.Add(new object[] { j, a.Category, a.Title, a.Publisher.Name, a.Date.Split('T')[0], a.Attachments.Length });
                        }
                    }
                }
            }
        }

        private void AnnouncementGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AnnouncementForm f1 = new AnnouncementForm(Program.Announcements[int.Parse(AnnouncementGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString())]);
                f1.ShowDialog();
            }
        }

        private void SelectAllCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CategoryListbox.Items.Count; i++)
            {
                CategoryListbox.SetItemChecked(i, true);
            }
        }

        private void UnselectAllCategory_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CategoryListbox.Items.Count; i++)
            {
                CategoryListbox.SetItemChecked(i, false);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string temp = SearchBar.Text;
            temp = StringEdit.ReplaceGreek(temp, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
            string[] searchValues = temp.Split(',');
            if (searchValues.Length > 0)
            {
                List<Announcement> searchResults = new List<Announcement>();
                if (AnnouncementGridView.Rows.Count - 1 != Program.Announcements.Count && AnnouncementGridView.Rows.Count > 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Αναζήτηση στην τρέχουσα λίστα?", "Διευκρίνηση", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < AnnouncementGridView.Rows.Count - 1; i++)
                        {
                            Announcement curAnnouncement = Program.Announcements[int.Parse(AnnouncementGridView.Rows[i].Cells["ID"].Value.ToString())];
                            foreach (string s in searchValues)
                            {
                                string temptext = StringEdit.ReplaceGreek(curAnnouncement.Text, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
                                string temptitle = StringEdit.ReplaceGreek(curAnnouncement.Title, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
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
                                string temptext = StringEdit.ReplaceGreek(curAnnouncement.Text, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
                                string temptitle = StringEdit.ReplaceGreek(curAnnouncement.Title, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
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
                            string temptext = StringEdit.ReplaceGreek(curAnnouncement.Text, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
                            string temptitle = StringEdit.ReplaceGreek(curAnnouncement.Title, CaseCheckbox.Checked, StressCheckbox.Checked, GrammarCheckbox.Checked);
                            if (temptitle.Contains(s) || temptext.Contains(s))
                            {
                                searchResults.Add(curAnnouncement);
                                break;
                            }
                        }
                    }
                }
                AnnouncementGridView.Rows.Clear();
                foreach (Announcement a in searchResults)
                {
                    int j = Program.Announcements.IndexOf(a);
                    AnnouncementGridView.Rows.Add(new object[] { j, a.Category, a.Title, a.Publisher.Name, a.Date.Split('T')[0], a.Attachments.Length });
                }
            }
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }
    }
}
