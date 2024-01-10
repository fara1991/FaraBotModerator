using System;
using System.IO;
using System.Text;
using System.Threading;
using FaraBotModerator.Enum;

namespace FaraBotModerator.controllers
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="eventEnum"></param>
        public static void OutputLog(string text, TwitchEventEnum eventEnum = TwitchEventEnum.None)
        {
            var date = DateTime.Now;
            string year = date.Year.ToString("00");
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");
            string hour = date.Hour.ToString("00");
            string minute = date.Minute.ToString("00");
            string second = date.Second.ToString("00");

            var directoryName = $@"{Directory.GetCurrentDirectory()}\Log";
            var fileName = $"{year}.{month}.{day}.log";
            var filePath = $@"{directoryName}\{fileName}";
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            
            // 排他制御
            using var mutex = new Mutex(false, fileName);
            mutex.WaitOne();
            using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                var logTime = $"[{year}/{month}/{day} {hour}:{minute}:{second}] ";
                var logText = logTime +  text;
                writer.WriteLine(logText);
            }

            mutex.ReleaseMutex();

            if (eventEnum == TwitchEventEnum.None) return;
            
            // Follow等のTwitchEventログは配信終了画像に自動で追加
            var eventFileName = $"{System.Enum.GetName(typeof(TwitchEventEnum), eventEnum)}_{year}.{month}.{day}.log";
            var eventFilePath = $@"{directoryName}\{eventFileName}";

            // 排他制御
            using var eventMutex = new Mutex(false, fileName);
            eventMutex.WaitOne();
            using (var writer = new StreamWriter(eventFilePath, true, Encoding.UTF8))
            {
                writer.WriteLine(text);
            }

            eventMutex.ReleaseMutex();
        }
    }
}