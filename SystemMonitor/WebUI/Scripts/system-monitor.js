
function loadTelemetry() {
    var url = "https://system-monitor-eneronov.azurewebsites.net/api/system-monitor/v1/get-telemetry-states/";
    
    $.get(url, function (data) {

        $("#output").empty();
        $("#output").append("<table><th>");

        $("#output").append("<td width='150px'><b>ProcessId</b></td>");
        $("#output").append("<td width='350px'><b>Name</b></td>");
        $("#output").append("<td width='150px'><b>CpuUsage</b></td>");
        $("#output").append("<td width='150px'><b>MemoryUsage</b></td>");
        

        $.each(data.Processes, function (key, value) {

            $("#output").append("<tr>");

            var processId = "<td>" + value.ProcessId + "</td>";
            var command = "<td>" + value.Name + "</td>";
            var cpuUsage = "<td>" + value.CpuUsage + "%</td>";
            var memoryUsage = "<td>" + value.MemoryUsage + " Mb</td>";

            $("#output").append(processId + command + cpuUsage + memoryUsage);

            $("#output").append("</tr>");
        });

        $("#output").append("</table>");
    });
}

$(function () {
    setInterval(loadTelemetry, 1000);
});