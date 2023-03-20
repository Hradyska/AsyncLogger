using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AsyncLogger
{
    public class Logwriter
    {
       // private static int _count = 0;
        public event EventHandler<int> WriteBackup;
        public static int Count { get; set; }
        public static string Log
        {
            get;
            private set;
        }

        public async Task WriteLog(DateTime time, LogType type, string message, string path, string fileName)
        {
            string log = $"{time.ToString("hh.mm.ss. dd.MM.yyyy")}: {type}: {message}{Environment.NewLine}\t";
            Log += log;
            Count++;
            await FileService.WriteToFile(log, path, fileName);
            Task.Delay(100).Wait();
            WriteBackup(this, Count);
        }

        public static async Task WriteLogToFile(string path, string fileName)
        {
            await FileService.WriteToFile(Log, path, fileName);
        }
    }
}
