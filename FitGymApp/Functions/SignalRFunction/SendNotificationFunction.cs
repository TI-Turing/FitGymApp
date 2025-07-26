using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Extensions.SignalRService;
using System.Net;

namespace FitGymApp.Functions.SignalRFunction
{
    public class SendNotificationFunction
    {
        [Function("SendNotification")]
        [SignalROutput(HubName = "notifications")]
        public async Task<SignalRMessageAction[]> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "send-notification")] HttpRequestData req)
        {
            string message = await req.ReadAsStringAsync();
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("Notification sent via SignalR.");
            return new[]
            {
                new SignalRMessageAction("newNotification", new object[] { message })
            };
        }
    }
}
