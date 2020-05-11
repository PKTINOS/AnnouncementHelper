using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnnouncementHelper
{
    public static class StringEdit
    {
        public enum OutType
        {
            Normal = 0,
            Error = 1,
            Success = 2,
            Alert = 3
        }
        /// <summary>
        /// Μορφοποιεί ένα string, με σκοπό να κάνει τις αναζητήσεις ανεξάρτητες
        /// από ορθογραφεία, τονισμό και κεφαλαία/μικρά
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caseReplace"></param>
        /// <param name="stressReplace"></param>
        /// <param name="grammarReplace"></param>
        /// <returns></returns>
        public static string ReplaceGreek(string text, bool caseReplace, bool stressReplace, bool grammarReplace)
        {
            string result = text;
            result = result.Replace("ς", "σ");

            if (stressReplace)
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
            if (caseReplace)
                result = text.ToLower();
            if (grammarReplace)
            {
                result = result.Replace("ώ", "ο");
                result = result.Replace("ω", "ο");
                result = result.Replace("ή", "ι");
                result = result.Replace("η", "ι");
                result = result.Replace("ύ", "ι");
                result = result.Replace("υ", "ι");
                result = result.Replace("υι", "ι");
                result = result.Replace("υί", "ι");
                result = result.Replace("ει", "ι");
                result = result.Replace("εί", "ι");
                result = result.Replace("οι", "ι");
                result = result.Replace("οί", "ι");
                result = result.Replace("αί", "ε");
                result = result.Replace("αι", "ε");
            }

            return result;
        }

        /// <summary>
        /// Εκτυπώνει κείμενο με συγκεκριμένο στυλ
        /// Βοηθάει στην ομορφοποίηση της κονσόλας αντί για Console.Write
        /// </summary>
        /// <param name="message">Το μήνυμα που θα εκτυπωθεί</param>
        /// <param name="outType">Συγκεκριμένο χρώμα ανάλογα με το OutType</param>
        public static void Out(string message, ref RichTextBox richTextBox, OutType outType = OutType.Normal)
        {
            #region consoleOut
            /*
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[");
            if (outType == OutType.Normal)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (outType == OutType.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (outType == OutType.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("~");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (outType == OutType.Alert)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("] ");
            Console.WriteLine(message);
            */
            #endregion


            Console.ForegroundColor = ConsoleColor.White;
            richTextBox.AppendText("[", Color.White);
            if (outType == OutType.Normal)
            {
                richTextBox.AppendText("~", Color.Gray);
            }
            else if (outType == OutType.Error)
            {
                richTextBox.AppendText("~", Color.Red);
            }
            else if (outType == OutType.Success)
            {
                richTextBox.AppendText("~", Color.Green);
            }
            else if (outType == OutType.Alert)
            {
                richTextBox.AppendText("~", Color.Yellow);
            }
            richTextBox.AppendText("]", Color.White);
            richTextBox.AppendText(" " + message + Environment.NewLine, Color.White);

        }
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
