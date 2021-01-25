using AnnouncementHelper.Tools;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
            BackColor = Program.BgColor;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BeforeAccessTokenWork();
        }


        private async void BeforeAccessTokenWork()
        {
            await Initialize();

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token"))
            {
                StringEdit.Out("Refresh token found!", ref richTextBox1,StringEdit.OutType.Success);
                await GetAccessTokenUsingRefresh(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token"));
                AfterAccessTokenWork();
            }
            else
            {
                StringEdit.Out("Please choose your login method and login.", ref richTextBox1);
                radiopanel.Enabled = true;
                loginBox.Enabled = true;
                loginManual.Enabled = true;
            }

        }

        private async void AfterAccessTokenWork()
        {
            if (Program.access_token == "error")
            {
                StringEdit.Out("Error when loading access token. Please report to the developer.", ref richTextBox1, StringEdit.OutType.Error);
                return;
            }
            var task1 = LoadCategories();
            var task2 = LoadUserProfile();
            var task3 = LoadAnnouncements();
            await Task.WhenAll(task1, task2, task3);

            this.Hide();
            var organizer = new Organizer();
            organizer.Closed += (s, args) => this.Close();
            organizer.Show();
        }
        private async Task Initialize()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk.GetValue("AnnouncementHelper") != null)
            {
                Program.StartupEnabled = true;
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\"))
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\");

            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\");
            foreach (string s in files)
            {
                string filename = s.Split('\\').Last();
                if (filename.Contains("reminder"))
                {
                    string date = filename.Split('_')[1].Split('T')[0];
                    if (DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture) <= DateTime.Now.Date)
                    {
                        StringEdit.Out("Βρέθηκε ανακοίνωση για σήμερα!", ref richTextBox1, StringEdit.OutType.Success);
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
                UseProxy = false,
            };
            client = new HttpClient(hch);
        }

        private async Task LoadCategories(){
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.iee.ihu.gr/categories/"))
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
                        return;
                    }
                    Category temp;
                    temp = JsonConvert.DeserializeObject<Category>(s);
                    temp.Index = i;
                    Program.Categories.Add(temp);
                    i++;
                }
                if (Program.Categories.Count > 0)
                {
                    StringEdit.Out("Found " + Program.Categories.Count + " categories.", ref richTextBox1, StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Something went wrong while fetching the categories.", ref richTextBox1, StringEdit.OutType.Error);
                    return;
                }
            }
        }

        private async Task LoadUserProfile(){
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.iee.ihu.gr/profile"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", Program.access_token);

                var response = await client.SendAsync(request);

                string responseString = await response.Content.ReadAsStringAsync();
                Program.UserProfile = JsonConvert.DeserializeObject<Profile>(responseString);
                if (Program.UserProfile.GivenName == string.Empty)
                {
                    StringEdit.Out("Something went wrong while fetching the profile.", ref richTextBox1, StringEdit.OutType.Error);
                    return;
                }
            }
            StringEdit.Out("Semester found:" + Program.UserProfile.Sem, ref richTextBox1);
        }

        private async Task LoadAnnouncements(){
            StringEdit.Out("Fetching announcements...", ref richTextBox1);
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.iee.ihu.gr/announcements"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", Program.access_token);

                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
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
                    StringEdit.Out("Found " + Program.Announcements.Count + " announcements.", ref richTextBox1, StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Something went wrong while fetching the announcements.", ref richTextBox1, StringEdit.OutType.Error);
                    return;
                }
            }
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

            var response = await client.PostAsync("https://login.iee.ihu.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {
                StringEdit.Out("JSON answer missing error.", ref richTextBox1, StringEdit.OutType.Error);
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Got access token using the refresh token!", ref richTextBox1, StringEdit.OutType.Success);
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token", matches[5].ToString().Replace("\"", ""));
                    Program.access_token = matches[1].ToString().Replace("\"", "");
                    return;
                }
                else
                {
                    StringEdit.Out("JSON error:" + Environment.NewLine + responseString, ref richTextBox1, StringEdit.OutType.Error);
                    StringEdit.Out("Possibly expired refresh_token.", ref richTextBox1);
                    StringEdit.Out("Please restart the program.", ref richTextBox1);
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token");
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

            var response = await client.PostAsync("https://login.iee.ihu.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {

                StringEdit.Out("JSON answer missing error.", ref richTextBox1, StringEdit.OutType.Error);
                return "error";
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Access token fetched!", ref richTextBox1, StringEdit.OutType.Success);
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\refresh.token", matches[5].ToString().Replace("\"", ""));
                    return matches[1].ToString().Replace("\"", "");
                }
                else
                {
                    StringEdit.Out("JSON error:" + Environment.NewLine + responseString, ref richTextBox1);
                    return "error";
                }
            }

        }

        private async Task<string> GetCodeWithLoginForm(string username, string password)
        {
            string link = "https://login.iee.ihu.gr/login?client_id=" + Program.CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html";
            HttpClientHandler hch = new HttpClientHandler
            {
                Proxy = null,
                UseProxy = false,
            };
            client = new HttpClient(hch);
            var values = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password },
                { "saveMeCheck" , "true"}
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(link, content);

            var responseString = await response.Content.ReadAsStringAsync();

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), link))
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                var xresponse = await client.SendAsync(request);
                string xresponseString = await xresponse.Content.ReadAsStringAsync();

                return xresponse.RequestMessage.RequestUri.ToString().Split('=')[1].Split('&')[0];
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                loginBox.Visible = true;
                loginManual.Visible = false;
            }
            else
            {
                loginBox.Visible = false;
                loginManual.Visible = true;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            loginBox.Enabled = false;
            string code = await GetCodeWithLoginForm(usernameInput.Text, passwordInput.Text);
            Program.access_token = await GetAccessToken(code);
            AfterAccessTokenWork();
        }

        private void passwordInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2_Click(this, new EventArgs());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string link = "https://login.iee.ihu.gr/login?client_id=" + Program.CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html";
            Process.Start(link);
            StringEdit.Out("Please use the opened browser window to authorize and paste the code back here.", ref richTextBox1, StringEdit.OutType.Alert);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string code = codeInput.Text;
            Program.access_token = await GetAccessToken(code);
            AfterAccessTokenWork();
        }
    }
}
