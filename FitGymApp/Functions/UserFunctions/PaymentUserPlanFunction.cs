using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FitGymApp.Functions.UserFunctions
{
    public class PaymentUserPlanFunction
    {
        private readonly ILogger<PaymentUserPlanFunction> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentUserPlanFunction(ILogger<PaymentUserPlanFunction> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [Function("User_ProcessUserPlanPayment")]
        public async Task<HttpResponseData> ProcessPaymentAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/payment")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("User_ProcessUserPlanPayment");
            logger.LogInformation("Processing user plan payment request.");

            if (!JwtValidator.ValidateJwt(req, out var error))
            {
                var unauthorizedResponse = req.CreateResponse(HttpStatusCode.Unauthorized);
                await unauthorizedResponse.WriteAsJsonAsync(new ApiResponse<bool>
                {
                    Success = false,
                    Message = error!,
                    Data = default,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
                return unauthorizedResponse;
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var paymentRequest = JsonConvert.DeserializeObject<PaymentRequestDto>(requestBody);

            var validationResponse = await _paymentService.ValidatePaymentAsync(paymentRequest);
            if (!validationResponse.Success)
            {
                var badRequestResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequestResponse.WriteAsJsonAsync(validationResponse);
                return badRequestResponse;
            }

            var paymentResponse = await _paymentService.ProcessPaymentAsync(paymentRequest);
            var response = req.CreateResponse(paymentResponse.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await response.WriteAsJsonAsync(paymentResponse);
            return response;
        }
    }
}