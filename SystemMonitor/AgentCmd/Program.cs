using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using CommonLib.Monitor;
using Newtonsoft.Json;

namespace AgentCmd
{
    class Program
    {
        public static Guid ComputerId = Guid.Parse("de98e506-546a-4346-b813-46da60373ed6");

        static void Main(string[] args)
        {
            var rand = new Random();

            var apiurl = "http://system-monitor-eneronov.azurewebsites.net/api/telemetry-receiver/v1/put/";

            while (true)
            {
                var localAll = Process.GetProcesses();

                var processes = localAll.Select(x => new ProcessInfo()
                {
                    ProcessId = x.Id,
                    Name = x.ProcessName,
                    CpuUsage = rand.Next(100),
                    MemoryUsage = rand.Next(10) * 10 + rand.Next(10) + 100 
                });

                var telemetryStates = new TelemetryStates()
                {
                    ComputerId = ComputerId,
                    Processes = processes.ToList()
                };

                using (var client = new WebClient())
                {
                    var encodedJson = JsonConvert.SerializeObject(telemetryStates);

                    client.Headers.Add("Content-Type:application/json");

                    var response = client.UploadString($"{apiurl}", encodedJson);

                    Console.WriteLine(response);
                }

                Console.WriteLine("Data sent..");

                Thread.Sleep(1000);
            }
        }
    }
}
