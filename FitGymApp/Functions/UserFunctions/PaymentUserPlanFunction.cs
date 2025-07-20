using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Application.Services.Payments;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO.Payment.Response;
using FitGymApp.Domain.Enums;
using FitGymApp.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace FitGymApp.Functions.UserFunctions
{
    public class PaymentUserPlanFunction
    {
        private readonly ILogger<PaymentUserPlanFunction> _logger;
        private readonly IPaymentGatewayService _paymentService;

        public PaymentUserPlanFunction(ILogger<PaymentUserPlanFunction> logger, IPaymentGatewayService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [Function("GeneratePaymentUrl")]
        public async Task<HttpResponseData> GeneratePaymentUrlAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/payment-url")] HttpRequestData req)
        {
            _logger.LogInformation("Generating payment URL.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var paymentRequest = JsonConvert.DeserializeObject<PaymentRequestDto>(requestBody);

            if (paymentRequest == null || paymentRequest.UserId == Guid.Empty || paymentRequest.Amount <= 0)
            {
                var badRequestResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequestResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid payment request.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return badRequestResponse;
            }

            try
            {
                string paymentUrl = await _paymentService.CreatePaymentUrlAsync(paymentRequest.UserId.ToString(), paymentRequest.Amount, paymentRequest.Description);

                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Payment URL generated successfully.",
                    Data = paymentUrl,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating payment URL.");

                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "An error occurred while generating the payment URL.",
                    Data = null,
                    StatusCode = StatusCodes.Status500InternalServerError
                });
                return errorResponse;
            }
        }

        [Function("PaymentWebhook")]
        public async Task<HttpResponseData> PaymentWebhookAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "webhook/payment")] HttpRequestData req)
        {
            _logger.LogInformation("Processing payment webhook.");

            try
            {
                // Convert HttpRequestData to HttpRequest
                var httpContext = new DefaultHttpContext();
                var httpRequest = req.ToHttpRequest(httpContext);

                var paymentStatus = await _paymentService.HandleWebhookAsync(httpRequest);

                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(new ApiResponse<PaymentStatusEnum>
                {
                    Success = true,
                    Message = "Webhook processed successfully.",
                    Data = paymentStatus,
                    StatusCode = StatusCodes.Status200OK
                });
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment webhook.");

                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<string>
                {
                    Success = false,
                    Message = "An error occurred while processing the webhook.",
                    Data = null,
                    StatusCode = StatusCodes.Status500InternalServerError
                });
                return errorResponse;
            }
        }
    }
}