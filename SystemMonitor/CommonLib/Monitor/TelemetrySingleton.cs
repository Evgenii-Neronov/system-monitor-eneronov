using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib.Basic;

namespace CommonLib.Monitor
{
    /// <summary>
    /// Telemetry singleton class
    /// </summary>
    public class TelemetrySingleton
    {
        private static readonly Dictionary<Guid, TelemetryStates> _telemetry;

        static TelemetrySingleton()
        {
            _telemetry = Singleton<Dictionary<Guid, TelemetryStates>>.GetObj.Model;
        }

        /// <summary>
        /// List computer Ids
        /// </summary>
        public IList<Guid> List()
        {
            return _telemetry.Keys.ToList();
        }

        /// <summary>
        /// Get TelemetryStates by computer Id
        /// </summary>
        public TelemetryStates Get(Guid computerId)
        {
            return _telemetry[computerId];
        }

        /// <summary>
        /// Put TelemetryStates of computer
        /// </summary>
        public void Put(Guid computerId, TelemetryStates telemetryStates)
        {
            _telemetry[computerId] = telemetryStates;
        }

        /// <summary>
        /// Reset all telemetry data
        /// </summary>
        public void Reset()
        {
            _telemetry.Clear();
        }
    }
}