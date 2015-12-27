using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TitanEditor
{
    class ini
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static bool MD5 = true;
        public static string ResetField = "resets";
        public static string Mail1;
        public static string Mail2;
        public static string Mail3;
        public static string Mail4;
        public static string MailSender;
        public static string MailSubject;

        public static string ReadString(string Section, string Key, string DefaultValue, string Path)
        {
            try
            {
                StringBuilder temp = new StringBuilder(2048);
                GetPrivateProfileString(Section, Key, "", temp, 255, Path);
                if (temp != null)
                    return (temp.ToString());
                else
                    return "";
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static int ReadInt(string Section, string Key, string DefaultValue, string Path)
        {
            try
            {
                StringBuilder temp = new StringBuilder(2048);
                GetPrivateProfileString(Section, Key, DefaultValue, temp, 255, Path);
                if (temp.Length == 0)
                    return 0;
                else
                    return (Convert.ToInt32(temp.ToString()));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static void WriteValue(string Section, string Key, object Value, string Path)
        {
            try
            {
                WritePrivateProfileString(Section, Key, Value.ToString(), Path);
            }
            catch (Exception)
            {
            }
        }
    }
}
