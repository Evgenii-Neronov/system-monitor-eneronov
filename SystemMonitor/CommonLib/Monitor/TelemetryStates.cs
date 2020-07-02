using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Monitor
{
    public class TelemetryStates
    {
        public Guid ComputerId { get; set; }
   
        public IList<ProcessInfo> Processes { get; set; }

        public TelemetryStates()
        {
            Processes = new List<ProcessInfo>();
        }
    }
}