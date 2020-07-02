using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Monitor
{
    public class ProcessInfo
    {
        public int ProcessId { get; set; }

        public string Name { get; set; }

        public string Command { get; set; }

        public string UserInfo { get; set; }

        public DateTime Created { get; set; }

        public double CpuUsage { get; set; }

        public double MemoryUsage { get; set; }
    }
}
