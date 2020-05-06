using System;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AnnouncementHelper
{
    class Program
    {
        // Κωδικοί της εφαρμογής
        private const string CLIENT_ID = "5eb300b88d8d2917ed03198d";
        private const string CLIENT_SECRET = "0sy2579v41pxpap3on2e1uigumgrlsfj67pt5rthmbr13hohpw";
        public const string VERSION = "1.0.2";

        public static List<Announcement> Announcements = new List<Announcement>();
        public static List<Category> Categories = new List<Category>();

        private static string access_token;
        private static HttpClient client;
        private static Profile userProfile;
        
        /// <summary>
        /// Entry point
        /// </summary>
        static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "AnnouncementHelper " + VERSION;

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
                StringEdit.Out("Βρέθηκε refresh token...");
                await GetAccessTokenUsingRefresh(File.ReadAllText(Environment.CurrentDirectory + "/refresh.token"));
            }
            else
            {
                StringEdit.Out("Παρακαλώ δώστε εξουσιοδότηση στην εφαρμογή.");
                StringEdit.Out("Έπειτα, εισάγετε τον αριθμό \"code\" που βλέπετε:");
                Process.Start("https://login.it.teithe.gr/authorization/?client_id=" + CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html");
                string code = Console.ReadLine();
                access_token = await GetAccessToken(code);
            }
           

            if (access_token == "error")
            {
                StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.", StringEdit.OutType.Error);
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Load categories
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/categories/"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", access_token);

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
                        StringEdit.Out(s);
                        Console.ReadLine();
                    }
                    Category temp;
                    temp = JsonConvert.DeserializeObject<Category>(s);
                    temp.Index = i;
                    Categories.Add(temp);
                    i++;
                }
                if (Categories.Count > 0)
                {
                    StringEdit.Out("Περάστηκαν " + Categories.Count + " κατηγορίες ανακοινώσεων.", StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη κατηγοριών ανακοινώσεων.", StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.", StringEdit.OutType.Error);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            // Load user profile
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/profile"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", access_token);

                var response = await client.SendAsync(request);

                string responseString = await response.Content.ReadAsStringAsync();
                userProfile = JsonConvert.DeserializeObject<Profile>(responseString);
                if (userProfile.GivenName == string.Empty)
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη profile.", StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.", StringEdit.OutType.Error);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            StringEdit.Out("Βρέθηκε εξάμηνο:" + userProfile.Sem);
            StringEdit.Out("Κατέβασμα ανακοινώσεων...");
            
            // Load announcements
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/announcements"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", access_token);
                
                var response = await client.SendAsync(request);
                string responseString = await response.Content.ReadAsStringAsync();
                    
                responseString = responseString.Replace("},{", "}^{");
                responseString = responseString.Substring(1, responseString.Length - 2);

                string[] vs = responseString.Split('^');
                    
                foreach (string s in vs)
                {
                    Announcement temp = JsonConvert.DeserializeObject<Announcement>(s);
                    Announcements.Add(temp);
                }

                if (Announcements.Count > 0)
                {
                    StringEdit.Out("Κατέβηκαν " + Announcements.Count + " ανακοινώσεις.", StringEdit.OutType.Success);
                }
                else
                {
                    StringEdit.Out("Κάτι πήγε στραβά κατά την λήψη ανακοινώσεων.", StringEdit.OutType.Error);
                    StringEdit.Out("Το πρόγραμμα τωρα θα τερματιστεί.", StringEdit.OutType.Error);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }

            Thread organizerThread = new Thread(() =>
            {
                Application.Run(new Organizer());
            })
            {
                IsBackground = true
            };
            organizerThread.Start();

            StringEdit.Out("Πατήστε enter για να τερματίσετε το πρόγραμμα.");
            Console.ReadLine();
        }

        /// <summary>
        /// Μετατροπή code που αποκτήθηκε απο authorization σε access_token
        /// </summary>
        private async static Task<string> GetAccessToken(string code)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "grant_type", "authorization_code" },
                { "code" , code }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.it.teithe.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {

                StringEdit.Out("Δεν βρέθηκε JSON απάντηση κατά την προσπάθεια απόκτησης Access Token.",StringEdit.OutType.Error);
                return "error";
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Access Token λήφθηκε!", StringEdit.OutType.Success);
                    File.WriteAllText(Environment.CurrentDirectory + "/refresh.token", matches[5].ToString().Replace("\"", ""));
                    return matches[1].ToString().Replace("\"","");
                }
                else
                {
                    StringEdit.Out("Error σε μορφή JSON:" + Environment.NewLine + matches[2].ToString());
                    return "error";
                }
            }
               
        }
        private async static Task GetAccessTokenUsingRefresh(string code)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", CLIENT_ID },
                { "client_secret", CLIENT_SECRET },
                { "grant_type", "refresh_token" },
                { "code" , code }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.it.teithe.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {
                StringEdit.Out("Δεν βρέθηκε JSON απάντηση κατά την προσπάθεια απόκτησης Access Token.", StringEdit.OutType.Error);
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    StringEdit.Out("Access Token λήφθηκε μέσω refresh token!", StringEdit.OutType.Success);
                    File.WriteAllText(Environment.CurrentDirectory + "/refresh.token", matches[5].ToString().Replace("\"", ""));
                    access_token = matches[1].ToString().Replace("\"", "");
                    return;
                }
                else
                {
                    StringEdit.Out("Error σε μορφή JSON:" + Environment.NewLine + matches[2].ToString(),StringEdit.OutType.Error);
                    StringEdit.Out("Λογικα έληξε το refresh_token");
                    StringEdit.Out("Παρακαλώ ξαναδώστε εξουσιοδότηση");
                    if (File.Exists(Environment.CurrentDirectory + "/refresh.token"))
                        File.Delete(Environment.CurrentDirectory + "/refresh.token");
                    Process.Start("https://login.it.teithe.gr/authorization/?client_id=" + CLIENT_ID + "&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html");
                    access_token = await GetAccessToken(Console.ReadLine());
                    return;
                }
            }
        }
    }
}
