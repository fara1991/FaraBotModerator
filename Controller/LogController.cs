using System;
using System.IO;
using System.Text;

namespace FaraBotModerator.Controller
{
    public static class LogController
    {
        public static void OutputLog(string logText)
        {
            var date = DateTime.Now;
            string year = date.Year.ToString("00");
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");
            string hour = date.Hour.ToString("00");
            string minute = date.Minute.ToString("00");
            string second = date.Second.ToString("00");

            var directoryName = $@"{Directory.GetCurrentDirectory()}\Log";
            var filePath = $@"{directoryName}\{year}.{month}.{day}.log";
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                var logTime = $"[{year}/{month}/{day} {hour}:{minute}:{second}]";
                writer.WriteLine($@"{logTime} {logText}");
            }
        }
    }
}