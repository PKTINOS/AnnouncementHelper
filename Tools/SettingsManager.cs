using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnouncementHelper.Tools
{
    public static class SettingsManager
    {
        /// <summary>
        /// Προσθέτει setting στο config file 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="group"></param>
        public static void ChangeSetting(string value, string group)
        {
            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\config.ah";
            if (!File.Exists(configPath)) 
                File.Create(configPath);
            List<string> lines = File.ReadAllLines(configPath).ToList();
            bool found = false;
            if (!lines.Contains(group))
            for(int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains("[" + group + "]"))
                {
                    found = true;
                    if (i + 1 == lines.Count) lines.Add(value);
                    else 
                    {
                        lines.RemoveAt(i + 1);
                        lines.Insert(i + 1, value);
                    } 
                }
            }
            if (!found)
            {
                lines.Add("[" + group + "]");
                lines.Add(value);
            }
            File.WriteAllLines(configPath, lines);
        }

        public static bool CheckSetting(string value)
        {
            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\config.ah";
            if (!File.Exists(configPath))
                return false;
            if (File.ReadAllLines(configPath).Contains(value))
                return true;
            return false;
        }

        public static string GetGroup(string group)
        {
            string result = "";
            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnnouncementHelper\\config.ah";
            if (!File.Exists(configPath))
                return null;
            string[] lines = File.ReadAllLines(configPath);
            bool capture = false;
            foreach (string line in lines)
            {
                if (line.Contains("["))
                {
                    capture = false;
                }
                if (capture)
                {
                    result = line;
                }
                if (line.Contains(group))
                {
                    capture = true;
                }
            }
            return result;
        }

        public static Color StringToColor(string s)
        {
            string[] parts = s.Split(';');
            
            return Color.FromArgb(255,int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }


        public static string ColorToString(Color c)
        {
            return c.R.ToString() + ";" + c.G.ToString() + ";" + c.B.ToString();
        }
    }
}
