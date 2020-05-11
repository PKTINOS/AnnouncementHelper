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
using System.Linq;
using System.Globalization;
using AnnouncementHelper.Tools;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing;
using AnnouncementHelper.Forms;

namespace AnnouncementHelper
{
    class Program
    {
        // Κωδικοί της εφαρμογής
        public const string CLIENT_ID = "5eb300b88d8d2917ed03198d";
        public const string CLIENT_SECRET = "0sy2579v41pxpap3on2e1uigumgrlsfj67pt5rthmbr13hohpw";
        public const string VERSION = "1.0.3";

        public static List<Announcement> Announcements = new List<Announcement>();
        public static List<Category> Categories = new List<Category>();

        public static string access_token;
        public static Profile UserProfile;

        public static bool StartupEnabled = false;
        public static bool HideMain = false;
        
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main()
        {
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
