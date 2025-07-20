using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitGymApp.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<string> CreatePaymentUrlAsync(string userId, decimal amount, string description);
        Task<PaymentStatusEnum> HandleWebhookAsync(HttpRequest req);
        Task<PaymentStatusEnum> CheckPaymentStatusAsync(string externalPaymentId);
    }
}
