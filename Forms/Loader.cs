using AnnouncementHelper.Tools;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnouncementHelper.Forms
{
    public partial class Loader : Form
    {
        private HttpClient client;
        public Loader()
        {
            InitializeComponent();
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            ShowInTaskbar = false;
            ShowInTaskbar = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            DoWork();
        }

        private async void DoWork()
        {

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk.GetValue("AnnouncementHelper") != null)
            {
                Program.StartupEnabled = true;
            }
            string[] files = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string s in files)
            {
                string filename = s.Split('\\').Last();
                if (filename.Contains("reminder"))
                {
                    string date = filename.Split('_')[1].Split('T')[0];
                    if (DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture) <= DateTime.Now.Date)
                    {
                        StringEdit.Out("Βρέθηκε ανακοίνωση για σήμερα!",ref richTextBox1, StringEdit.OutType.Success);
                        await Task.Delay(1000);
                        Announcement temp = AnnouncementConvert.FromBase64(File.ReadAllText(s));
                        File.Delete(s);
                        new Thread(() =>
                        {
                            AnnouncementForm f1 = new AnnouncementForm(temp);
                            f1.ShowDialog();
                        })
                        { IsBackground = true }.Start();
                    }
                }
            }
            // Το httpClient χρησιμοποιεί proxy σαν default που το κάνει αργό
            // οπότε το αφαιρούμε 
            HttpClientHandler hch = new HttpClientHandler
            {
                Proxy = null,
                UseProxy = false
            };
            client = new HttpClient(hch);

            if (File.Exists(Environment.CurrentDirectory + "/refresh.token"))
            {
                StringEdit.Out("Βρέθηκε refresh token...",ref richTextBox1);
                await GetAccessTokenUsingRefresh(File.ReadAllText(Environment.CurrentDirectory + "/refresh.token"));
                progressBar1.Value = 10;
            }
            else
            {
                StringEdit.Out("Παρακαλώ δώστε εξουσιοδότηση στην εφαρμογή.",ref richTextBox1);
                StringEdit.Out("Έπειτα, εισάγετε τον αριθμό \"code\" που βλέπετε:",ref richTextBox1);
                Process.Start("https://login.it.teithe.gr/authorization/?client_id=" + Program.CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html");
                richTextBox1.Refresh();
                string code = Interaction.InputBox("Code:", "Insert code","",0,0);
                Program.access_token = await GetAccessToken(code);
                progressBar1.Value = 10;
            }

            if (Program.access_token == "error")
            {
                StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.",ref richTextBox1, StringEdit.OutType.Error);
                await Task.Delay(2000);
                Close();
            }

            // Load Program.Categories
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/categories/"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", Program.access_token);

                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                responseString = responseString.Replace("},{", "}^{");
                responseString = responseString.Substring(1, responseString.Length - 2);
                string[] vs = responseString.Split('^');
                int i = 0;
                foreach (string s in vs)
                {
                    if (s.Contains("error"))
                    {
                        StringEdit.Out(s, ref richTextBox1);
                        await Task.Delay(2000);
                        Close();
                    }
                    Category temp;
                    temp = JsonConvert.DeserializeObject<Category>(s);
                    temp.Index = i;
                    Program.Categories.Add(temp);
                    i++;
                }
                if (Program.Categories.Count > 0)
                {
                    StringEdit.Out("Περάστηκαν " + Program.Categories.Count + " κατηγορίες ανακοινώσεων.",ref richTextBox1, StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη κατηγοριών ανακοινώσεων.",ref richTextBox1, StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.",ref richTextBox1, StringEdit.OutType.Error);
                    await Task.Delay(2000);
                    Close();
                }
            }
            progressBar1.Value = 30;
            // Load user profile
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/profile"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", Program.access_token);

                var response = await client.SendAsync(request);

                string responseString = await response.Content.ReadAsStringAsync();
                Program.UserProfile = JsonConvert.DeserializeObject<Profile>(responseString);
                if (Program.UserProfile.GivenName == string.Empty)
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη profile.",ref richTextBox1, StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.",ref richTextBox1, StringEdit.OutType.Error);
                    await Task.Delay(2000);
                    Close();
                }
            }
            progressBar1.Value = 55;
            StringEdit.Out("Βρέθηκε εξάμηνο:" + Program.UserProfile.Sem, ref richTextBox1);
            StringEdit.Out("Κατέβασμα ανακοινώσεων...",ref richTextBox1);

            // Load announcements
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/announcements"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", Program.access_token);

                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                progressBar1.Value = 90;
                responseString = responseString.Replace("},{", "}^{");
                responseString = responseString.Substring(1, responseString.Length - 2);

                string[] vs = responseString.Split('^');

                foreach (string s in vs)
                {
                    Announcement temp = JsonConvert.DeserializeObject<Announcement>(s);
                    Program.Announcements.Add(temp);
                }
                if (Program.Announcements.Count > 0)
                {
                    StringEdit.Out("Κατέβηκαν " + Program.Announcements.Count + " ανακοινώσεις.",ref richTextBox1, StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη ανακοινώσεων.",ref richTextBox1, StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.",ref richTextBox1, StringEdit.OutType.Error);
                    await Task.Delay(2000);
                    Close();
                }
            }
            progressBar1.Value = 100;
            await Task.Delay(1000);
            this.Hide();
            var organizer = new Organizer();
            organizer.Closed += (s, args) => this.Close();
            organizer.Show();
        }

        private async Task GetAccessTokenUsingRefresh(string code)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", Program.CLIENT_ID },
                { "client_secret", Program.CLIENT_SECRET },
                { "grant_type", "refresh_token" },
                { "code" , code }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.it.teithe.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {
                StringEdit.Out("Δεν βρέθηκε JSON απάντηση κατά την προσπάθεια απόκτησης Access Token.",ref richTextBox1, StringEdit.OutType.Error);
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Access Token λήφθηκε μέσω refresh token!",ref richTextBox1, StringEdit.OutType.Success);
                    File.WriteAllText(Environment.CurrentDirectory + "/refresh.token", matches[5].ToString().Replace("\"", ""));
                    Program.access_token = matches[1].ToString().Replace("\"", "");
                    return;
                }
                else
                {
                    StringEdit.Out("Error σε μορφή JSON:" + Environment.NewLine + matches[2].ToString(),ref richTextBox1, StringEdit.OutType.Error);
                    StringEdit.Out("Λογικα έληξε το refresh_token",ref richTextBox1);
                    StringEdit.Out("Παρακαλώ ξαναδώστε εξουσιοδότηση",ref richTextBox1);
                    if (File.Exists(Environment.CurrentDirectory + "/refresh.token"))
                        File.Delete(Environment.CurrentDirectory + "/refresh.token");
                    Process.Start("https://login.it.teithe.gr/authorization/?client_id=" + Program.CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html");
                    richTextBox1.Refresh();
                    Program.access_token = await GetAccessToken(Interaction.InputBox("Code:", "Insert code","",0,0));
                    return;
                }
            }
        }

        /// <summary>
        /// Μετατροπή code που αποκτήθηκε απο authorization σε access_token
        /// </summary>
        private async Task<string> GetAccessToken(string code)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", Program.CLIENT_ID },
                { "client_secret", Program.CLIENT_SECRET },
                { "grant_type", "authorization_code" },
                { "code" , code }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.it.teithe.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {

                StringEdit.Out("Δεν βρέθηκε JSON απάντηση κατά την προσπάθεια απόκτησης Access Token.",ref richTextBox1, StringEdit.OutType.Error);
                return "error";
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Access Token λήφθηκε!",ref richTextBox1, StringEdit.OutType.Success);
                    File.WriteAllText(Environment.CurrentDirectory + "/refresh.token", matches[5].ToString().Replace("\"", ""));
                    return matches[1].ToString().Replace("\"", "");
                }
                else
                {
                    StringEdit.Out("Error σε μορφή JSON:" + Environment.NewLine + matches[2].ToString(), ref richTextBox1);
                    return "error";
                }
            }

        }
    }
}
