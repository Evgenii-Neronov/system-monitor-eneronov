using System.Web.Http;
using CommonLib.Monitor;

namespace WebApi.Controllers
{
    /// <summary>
    /// Telemetry data receiver from observed clients
    /// </summary>
    public class TelemetryReceiverController : ApiController
    {
        private readonly TelemetrySingleton _telemetry;

        public TelemetryReceiverController()
        {
            _telemetry = new TelemetrySingleton();
        }

        /// <summary>
        /// Put telemetry states
        /// </summary>
        [HttpPost]
        [Route("api/telemetry-receiver/v1/put/")]
        public void Put([FromBody]TelemetryStates telemetryStates)
        {
            _telemetry.Put(telemetryStates.ComputerId, telemetryStates);
        }
    }
}