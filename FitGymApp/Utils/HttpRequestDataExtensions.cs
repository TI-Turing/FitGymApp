using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Http;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace FitGymApp.Utils
{
    public static class HttpRequestDataConverter
    {
        public static HttpRequest ToHttpRequest(this HttpRequestData req, HttpContext context)
        {
            var request = context.Request;

            // Copy method
            request.Method = req.Method;

            // Copy headers
            foreach (var header in req.Headers)
            {
                request.Headers[header.Key] = header.Value.ToArray();
            }

            // Copy body
            if (req.Body != null)
            {
                using var reader = new StreamReader(req.Body);
                var body = reader.ReadToEndAsync().Result;
                var memoryStream = new MemoryStream();
                var writer = new StreamWriter(memoryStream);
                writer.Write(body);
                writer.Flush();
                memoryStream.Position = 0;
                request.Body = memoryStream;
            }

            return request;
        }
    }
}