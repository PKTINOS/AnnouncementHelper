using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementHelper.Tools
{
    public static class AnnouncementConvert
    {   
        public static string ToBase64 (Announcement announcement)
        {
            // Make a string to encode
            // with seperator ^ for each member
            // of the class so we can load 
            // a simple base64 string
            // as an announcement
            string temp = "";
            temp += announcement.Publisher.Id + "^";
            temp += announcement.Publisher.Name + "^";
            temp += announcement.Title.Replace("^", "/\\") + "^";
            temp += announcement.Text.Replace("^", "/\\") + "^";
            temp += announcement.Date + "^";
            temp += announcement.CategoryId + "^";
            temp += announcement.AnnouncementHash;
            var plainTextBytes = Encoding.UTF8.GetBytes(temp);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static Announcement FromBase64(string encodedAnnouncement)
        {
            var base64EncodedBytes =Convert.FromBase64String(encodedAnnouncement);
            string temp = Encoding.UTF8.GetString(base64EncodedBytes);
            string[] valueArray = temp.Split('^');
            Announcement announcement = new Announcement
            {
                Publisher = new Publisher()
                {
                    Id = valueArray[0],
                    Name = valueArray[1]
                },
                Title = valueArray[2],
                Text = valueArray[3],
                Date = valueArray[4],
                CategoryId = valueArray[5],
                AnnouncementHash = valueArray[6]
            };
            return announcement;
        }
        public static void CreateReminder(string date, string base64Announcement)
        {
            File.WriteAllText(Environment.CurrentDirectory + "\\reminder_"+date, base64Announcement);
        }
    }
}
