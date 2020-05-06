using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace MyFirstTeitheApplication
{
    class Program
    {
        public static string access_token;
        private static HttpClient client;
        private static Profile userProfile;
        public static List<Announcement> Announcements = new List<Announcement>();
        private static List<Announcement> semesterAnnouncements = new List<Announcement>();
        private static List<Announcement> unreadAnnouncements = new List<Announcement>();
        public static List<Category> categories = new List<Category>();
        private static int[] ids = new int[10];
        enum OutType { 
            normal = 0,
            error = 1,
            success = 2,
            alert = 3
        }
        private static void Out(string message,OutType outType = OutType.normal)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            if (outType == OutType.normal)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }else if (outType == OutType.error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (outType == OutType.success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }else if (outType == OutType.alert)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("] ");
            Console.WriteLine(message);
        }
        static async Task Main(string[] args)
        {
            HttpClientHandler hch = new HttpClientHandler
            {
                Proxy = null,
                UseProxy = false
            };
            client = new HttpClient(hch);

            Console.OutputEncoding = Encoding.UTF8;
            Out("Παρακαλώ δώστε εξουσιοδότηση στην εφαρμογή.");
            Process.Start("https://login.it.teithe.gr/authorization/?client_id=5eaad78975d3025278b778c1&response_type=code&scope=announcements,notifications,profile&redirect_uri=https://users.it.teithe.gr/~it185246/accepted.html");
            Out("Έπειτα, εισάγετε τον αριθμό \"code\" που βλέπετε:");
            string code = Console.ReadLine();
            access_token = await GetToken(code);
            if (access_token == "error")
            {
                Out("Το πρόγραμμα τωρα θα τερματιστεί.", OutType.error);
                Console.ReadLine();
                Environment.Exit(0);
            }

            //Categories
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
                    Category temp;
                    temp = JsonConvert.DeserializeObject<Category>(s);
                    temp.index = i;
                    categories.Add(temp);
                    i++;
                }

            }
            if (categories.Count > 0)
            {
                Out("Περάστηκαν " + categories.Count + " κατηγορίες ανακοινώσεων.", OutType.success);
            }
            else
            {
                Out("Κάτι πήγε στραβά κατά την λήψη κατηγοριών ανακοινώσεων.", OutType.error);
                Out("Το πρόγραμμα τωρα θα τερματιστεί.", OutType.error);
                Console.ReadLine();
                Environment.Exit(0);
            }

            //Profile
            using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://api.it.teithe.gr/profile"))
            {
                request.Headers.TryAddWithoutValidation("x-access-token", access_token);

                var response = await client.SendAsync(request);

                string responseString = await response.Content.ReadAsStringAsync();
                userProfile = JsonConvert.DeserializeObject<Profile>(responseString);
            }
            if (userProfile.givenName == String.Empty)
            {
                Out("Κάτι πήγε στραβά κατά την λήψη profile.",OutType.error);
                Out("Το πρόγραμμα τωρα θα τερματιστεί.", OutType.error);
                Console.ReadLine();
                Environment.Exit(0);
            }
            Out("Βρέθηκε εξάμηνο:" + userProfile.sem);
            string semesterid = "";
            foreach(Category c in categories)
            {
                if (c.name.ToLower().Contains(userProfile.sem + "ο"))
                {
                    semesterid = c._id;
                    break;
                }
            }
            if (semesterid == "")
            {
                Out("Κάτι πήγε στραβά κατά την εύρεση της κατηγορίας του εξαμήνου σας.", OutType.error);
                Out("Το πρόγραμμα τωρα θα τερματιστεί.", OutType.error);
                Console.ReadLine();
                Environment.Exit(0);
            }
            Out("Κατέβασμα ανακοινώσεων...");
            
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
            }
            Out("Κατέβηκαν " + Announcements.Count + " ανακοινώσεις.", OutType.success);


            Thread organizerThread = new Thread(() => {
                Application.Run(new Organizer());
            });
            organizerThread.IsBackground = true;
            organizerThread.Start();

            /*
            if (showAnnouncements)
            {
                foreach (Announcement a in Announcements)
                {
                    if (a._about == semesterid)
                    {
                        semesterAnnouncements.Add(a);
                    }
                }
                Out("Βρέθηκαν " + semesterAnnouncements.Count + " ανακοινώσεις εξαμήνου.", OutType.success);
                List<string> curIds;
                curIds = new List<string>(File.ReadAllLines(Environment.CurrentDirectory + "/itconfig.cfg"));

                for (int i = 0; i < 10; i++)
                    if (!curIds.Contains(CreateMD5(semesterAnnouncements[i].Text)))
                        unreadAnnouncements.Add(semesterAnnouncements[i]);

                Out(unreadAnnouncements.Count.ToString() + " αδιάβαστες ανακοινώσεις (στις 10 πιο πρόσφατες)", OutType.alert);
                Console.ReadLine();
                for (int i = 0; i < unreadAnnouncements.Count; i++)
                {
                    PrintAnnouncement(unreadAnnouncements[i]);
                    Console.ReadLine();
                }
            }
            */
            Out("Πατήστε enter για να τερματίσετε το πρόγραμμα.");
            Console.ReadLine();
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        private async static Task<string> GetToken(string code)
        {
            var values = new Dictionary<string, string>
            {
                { "client_id", "5eaad78975d3025278b778c1" },
                { "client_secret", "3zbgjnm8y3gmuwud4j2xum21qud926lo3tfwsl75obejmovm2h" },
                { "grant_type", "authorization_code" },
                { "code" ,code}
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://login.it.teithe.gr/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            MatchCollection matches = Regex.Matches(responseString, "\"([^\"]*)\"");
            if (matches.Count == 0)
            {
                Out("Δεν βρέθηκε JSON απάντηση κατά την προσπάθεια απόκτησης Access Token.",OutType.error);
                return "error";
            }
            else
            {
                if (matches[0].ToString().Contains("access_token"))
                {
                    Out("Access Token λήφθηκε!", OutType.success);
                    return matches[1].ToString().Replace("\"","");
                }
                else
                {
                    Out("Error σε μορφή JSON:" + matches[1].ToString());
                    return "error";
                }
            }
               
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        /*
        private static void PrintAnnouncement(Announcement announcement)
        {
            //Seen
            foreach (Announcement an in unreadAnnouncements)
            {
                string temp = CreateMD5(an.Text);
                if (!new List<string>(File.ReadAllLines(Environment.CurrentDirectory + "/itconfig.cfg")).Contains(temp))
                {
                    File.AppendAllLines(Environment.CurrentDirectory + "/itconfig.cfg", new string[1] { temp });
                }

            }
            Console.Clear();
            Out("+-------------------------------------------------+-----+");
            Out("|" + announcement.Title.Substring(0, announcement.Title.Length > 46 ? 45 : announcement.Title.Length) + "... |" + announcement.category.Substring(0,5)+"|");
            Out("+-------------------------------------------------+-----+");
            int end = 55;
            int start = 0;
            announcement.editedtext = Regex.Replace(announcement.Text, @"\r\n?|\n", "");
            do {
                if (start + end < announcement.editedtext.Length)
                Out("|" + announcement.editedtext.Substring(start, end) + "|");
                else
                {
                    string temptext = announcement.editedtext.Substring(start, announcement.editedtext.Length - start);
                    int l = temptext.Length;
                    for (int i = 0; i < 55 - l; i++)
                    {
                        temptext += " ";
                    }
                    Out("|" + temptext + "|");
                    break;
                }
                start += 55;
            } while (true);

            Out("+-------------------------------------------------------+");

            ConsoleKey keyresponse;
            do
            {
                Out("Θέλετε να ανοίξετε την ανακοίνωση σε νέο παράθυρο; (y/n)");
                keyresponse = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                Console.WriteLine();

            } while (keyresponse != ConsoleKey.Y && keyresponse != ConsoleKey.N);
            if (keyresponse == ConsoleKey.Y)
            {
                AnnouncementForm f1 = new AnnouncementForm(announcement);
                f1.ShowDialog();
            }
        }*/

        public static string ReplaceGreek(string text,bool caseReplace,bool stressReplace,bool grammarReplace)
        {
            string result = text;
            result = result.Replace("ς", "σ");
            //Για πιο ευκολη αναζητηση, ακομα κιαν η ανακοινωση δεν εχει τονους
            if (!stressReplace)
            {
                result = result.Replace("ά", "α");
                result = result.Replace("ό", "ο");
                result = result.Replace("έ", "ε");
                result = result.Replace("ί", "ι");
                result = result.Replace("ύ", "υ");
                result = result.Replace("ή", "η");
                result = result.Replace("ώ", "ω");
                result = result.Replace("Ά", "Α");
                result = result.Replace("Ό", "Ο");
                result = result.Replace("Έ", "Ε");
                result = result.Replace("Ί", "Ι");
                result = result.Replace("Ύ", "Υ");
                result = result.Replace("Ή", "Η");
                result = result.Replace("Ώ", "Ω");
            }
            if (!caseReplace)
                result = text.ToLower();
            //Για πιο ευκολη αναζητηση, ακομα κιαν η ανακοινωση εχει γραμματικα λαθη
            if (!grammarReplace)
            {
                result = result.Replace("ώ", "ο");
                result = result.Replace("ω", "ο");
                result = result.Replace("ή", "ι");
                result = result.Replace("η", "ι");
                result = result.Replace("ύ", "ι");
                result = result.Replace("υ", "ι");
                result = result.Replace("ει", "ι");
                result = result.Replace("εί", "ι");
                result = result.Replace("οι", "ι");
                result = result.Replace("οί", "ι");
                result = result.Replace("αί", "ε");
                result = result.Replace("αι", "ι");
            }

            return result;
        }
   
    } //end of class program


    class Profile
    {
        public string uid
        {
            get;
            set;
        }
        public string am
        {
            get;
            set;
        }
        public string regyear
        {
            get;
            set;
        }
        public string regsem
        {
            get;
            set;
        }
        public string givenName
        {
            get;
            set;
        }
        public string sn //Last name
        {
            get;
            set;
        }
        public string cn //Full name
        {
            get;
            set;
        }
        public string description //Full name
        {
            get;
            set;
        }
        public string mail
        {
            get;
            set;
        }
        public string sem
        {
            get;
            set;
        }
    }
    class Category
    {
        public int index
        {
            get;
            set;
        }
        public string _id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        public string nameEn
        {
            get;
            set;
        }
        [JsonProperty(PropertyName = "public")]
        public bool isPublic
        {
            get;
            set;
        }
    }
 

}
