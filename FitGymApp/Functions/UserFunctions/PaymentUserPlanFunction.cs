using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO.User.Request;

namespace FitGymApp.Functions.UserFunctions
{
    public class PaymentUserPlanFunction
    {
        private readonly IPaymentService _paymentService;

        public PaymentUserPlanFunction(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [FunctionName("ProcessUserPlanPayment")]
        public async Task Run([QueueTrigger("user-plan-payments")] PaymentRequestDto paymentRequest, ILogger log)
        {
            log.LogInformation("Processing payment for UserId: {UserId}", paymentRequest.UserId);

            try
            {
                var validationResponse = await _paymentService.ValidatePaymentAsync(paymentRequest);
                if (!validationResponse.Success)
                {
                    log.LogWarning("Payment validation failed for UserId: {UserId}. Reason: {Reason}", paymentRequest.UserId, validationResponse.Message);
                    return;
                }

                var paymentResponse = await _paymentService.ProcessPaymentAsync(paymentRequest);
                if (paymentResponse.Success)
                {
                    log.LogInformation("Payment processed successfully for UserId: {UserId}", paymentRequest.UserId);
                }
                else
                {
                    log.LogWarning("Payment failed for UserId: {UserId}. Reason: {Reason}", paymentRequest.UserId, paymentResponse.Message);
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while processing payment for UserId: {UserId}", paymentRequest.UserId);
            }
        }
    }
}