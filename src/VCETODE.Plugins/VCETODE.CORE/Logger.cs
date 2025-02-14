using System;
using System.IO;

namespace VCETODE.Core
{
    /// <summary>
    /// A simple static logger to record errors and informational messages.
    /// </summary>
    public static class Logger
    {
        private static readonly string logDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VCETODE");
        private static readonly string logFilePath = Path.Combine(logDirectory, "log.txt");

        static Logger()
        {
            try
            {
                Directory.CreateDirectory(logDirectory);
            }
            catch { /* Suppress exceptions in logger initialization */ }
        }

        public static void LogError(string message, Exception ex = null)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} ERROR: {message}");
                    if (ex != null)
                    {
                        sw.WriteLine(ex.ToString());
                    }
                }
            }
            catch { }
        }

        public static void LogInfo(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} INFO: {message}");
                }
            }
            catch { }
        }
    }
}
