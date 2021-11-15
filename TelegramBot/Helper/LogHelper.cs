﻿using System;
using System.IO;

namespace Telegram.Bot.WinForm.Helper
{
    public static class LogHelper
    {
        public static void Log(string stringText)
        {
            try
            {
                if (string.IsNullOrEmpty(stringText)) return;
                //StreamWriter streamWriter;
                string directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                directoryName = string.Concat(directoryName, "\\Logs");
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                DateTime now = DateTime.Now;
                string str = string.Concat(directoryName, "\\Log_", now.ToString("dd-MM-yyyy"), ".txt");
                using (var streamWriter = new StreamWriter(str, true))
                {
                    //streamWriter = (File.Exists(str) ? File.AppendText(str) : new StreamWriter(str));
                    streamWriter.WriteLine(string.Format("{0} {1}", DateTime.Now, stringText));
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
            catch (Exception)
            {

            }

        }

        public static void LogError(string stringText)
        {
            try
            {
                if (string.IsNullOrEmpty(stringText)) return;
                //StreamWriter streamWriter;
                string directoryName = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                directoryName = string.Concat(directoryName, "\\Logs");
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                DateTime now = DateTime.Now;
                string str = string.Concat(directoryName, "\\ErrorLog_", now.ToString("dd-MM-yyyy"), ".txt");
                using (var streamWriter = new StreamWriter(str, true))
                {
                    //streamWriter = (File.Exists(str) ? File.AppendText(str) : new StreamWriter(str));
                    streamWriter.WriteLine(string.Format("{0} {1}", DateTime.Now, stringText));
                    streamWriter.Close();
                    streamWriter.Dispose();
                }


            }
            catch (Exception)
            {

            }

        }
    }
}
