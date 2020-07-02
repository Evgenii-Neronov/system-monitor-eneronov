using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class TelemetryData
    {
        public Guid ClientId { get; set; }
    }

    public class TelemetryItem
    {
        public TelemetryType TelemetryType { get; set; }

        public double Value { get; set; }
    }

    public enum TelemetryType : byte
    {
       Cpu = 1,
       Memory = 2,
    }
}