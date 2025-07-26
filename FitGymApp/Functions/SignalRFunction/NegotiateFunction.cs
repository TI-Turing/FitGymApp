using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.SignalRService;
using System.Net;

namespace FitGymApp.Functions.SignalRFunction
{
    public class NegotiateFunction
    {
        [Function("negotiate")]
        public SignalRConnectionInfo Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", "get", Route = "negotiate")] HttpRequestData req,
            [SignalRConnectionInfoInput(HubName = "notifications")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }
    }
}
