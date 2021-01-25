using AnnouncementHelper.Forms;
using AnnouncementHelper.Tools;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnnouncementHelper
{
    class Program
    {
        // Κωδικοί της εφαρμογής
        public const string CLIENT_ID = "5eb300b88d8d2917ed03198d";
        public const string CLIENT_SECRET = "0sy2579v41pxpap3on2e1uigumgrlsfj67pt5rthmbr13hohpw";
        public const string VERSION = "1.1.0";

        public static List<Announcement> Announcements = new List<Announcement>();
        public static List<Category> Categories = new List<Category>();

        public static string access_token;
        public static Profile UserProfile;

        public static bool StartupEnabled = false;
        public static bool HideMain = false;

        public static Color BgColor = Color.CornflowerBlue;

        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
            string colorcode = SettingsManager.GetGroup("Color");
            if (colorcode != null && colorcode != "") 
            BgColor = SettingsManager.StringToColor(colorcode);
            Application.Run(new Loader());
        }
        public static void SetStartup(bool set)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (set)
                rk.SetValue("AnnouncementHelper", Application.ExecutablePath);
            else
                rk.DeleteValue("AnnouncementHelper", false);
            StartupEnabled = set;

        }
    }


    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
