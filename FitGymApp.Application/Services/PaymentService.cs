using System;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FitGymApp.Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IPaymentRepository paymentRepository, ILogger<PaymentService> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponse<bool>> ValidatePaymentAsync(PaymentRequestDto paymentRequest)
        {
            _logger.LogInformation("Validating payment for UserId: {UserId}", paymentRequest.UserId);
            // Placeholder for validation logic
            return new ApplicationResponse<bool> { Success = true, Data = true };
        }

        public async Task<ApplicationResponse<bool>> ProcessPaymentAsync(PaymentRequestDto paymentRequest)
        {
            _logger.LogInformation("Processing payment for UserId: {UserId}", paymentRequest.UserId);
            return await _paymentRepository.ProcessPaymentAsync(paymentRequest);
        }
    }
}