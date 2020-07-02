using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CommonLib.Monitor;
using WebApi.Models;

namespace WebApi.Controllers
{
    /// <summary>
    /// Provides telemetry data of observed clients
    /// </summary>
    public class SystemMonitorController : ApiController
    {
        private readonly TelemetrySingleton _telemetry;

        public SocketNotifier SocketNotifier = new SocketNotifier();

        public SystemMonitorController()
        {
            _telemetry = new TelemetrySingleton();
        }

        /// <summary>
        /// Get telemetry states
        /// </summary>
        [HttpGet]
        [Route("api/system-monitor/v1/get-telemetry-states/")]
        public TelemetryStates GetTelemetryStates()
        {
            var ids = _telemetry.List();

            if (ids.Any() == false)
            {
                return null;
            }

            var firstKey = _telemetry.List().First();

            return _telemetry.Get(firstKey);
        }
        
        /// <summary>
        /// Connect via web sockets
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/system-monitor/v1/connect/")]
        public HttpResponseMessage Connect()
        {
            this.SocketNotifier.ProcessRequest(HttpContext.Current);

            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }
    }
}
