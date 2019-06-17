using System;
using System.IO;
using Flir.BusinessLayer;

namespace Flir.CameraTestConsoleApp
{
    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogError(string msg)
        {
            Log(msg, LogType.Error.ToString());
        }

        public void LogInfo(string msg)
        {
            Log(msg, LogType.Info.ToString());
        }

        private void Log(string msg, string msgType)
        {
            using (var streamWriter = new StreamWriter(_path, true))
            {
                streamWriter.WriteLine($"{msgType}: {msg} {DateTime.Now}");
            }
        }
    }
}