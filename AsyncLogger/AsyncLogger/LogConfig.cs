using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLogger
{
    public class LogConfig
    {
        public string Path { get; set; }
        public string LogName { get; set; }
        public string TimeFormat { get; set; }
        public int N { get; set; }
        public string BackupPath { get; set; }
    }
}
