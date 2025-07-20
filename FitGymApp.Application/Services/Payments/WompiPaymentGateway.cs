using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using FitGymApp.Domain.Enums;
using Microsoft.Azure.Functions.Worker.Http;
using System.Text.Json.Nodes;

namespace FitGymApp.Application.Services.Payments
{
    public class WompiPaymentGateway : IPaymentGatewayService
    {
        private readonly string _publicKey = Environment.GetEnvironmentVariable("WOMPI_PUBLIC_KEY");
        private readonly string _privateKey = Environment.GetEnvironmentVariable("WOMPI_PRIVATE_KEY");
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<string> CreatePaymentUrlAsync(string userId, decimal amount, string description)
        {
            var requestBody = new
            {
                public_key = _publicKey,
                amount_in_cents = (int)(amount * 100),
                currency = "COP",
                customer_email = userId, // Assuming userId is an email
                payment_method_type = "PSE",
                reference = Guid.NewGuid().ToString(),
                description = description
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://sandbox.wompi.co/v1/transactions", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to create payment URL");
            }

            var responseData = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            return responseData?["data"]?["checkout_url"]?.ToString();
        }

        public async Task<PaymentStatusEnum> HandleWebhookAsync(HttpRequest req)
        {
            using var reader = new StreamReader(req.Body);
            var body = await reader.ReadToEndAsync();

            var signature = req.Headers["X-Wompi-Signature"].FirstOrDefault();
            if (string.IsNullOrEmpty(signature) || !ValidateSignature(body, signature))
            {
                throw new Exception("Invalid webhook signature");
            }

            var webhookData = JsonNode.Parse(body);
            var transactionStatus = webhookData?["data"]?["transaction"]?["status"]?.ToString();

            return Enum.TryParse(transactionStatus, true, out PaymentStatusEnum status) ? status : PaymentStatusEnum.Pending;
        }

        public async Task<PaymentStatusEnum> CheckPaymentStatusAsync(string externalPaymentId)
        {
            var response = await _httpClient.GetAsync($"https://sandbox.wompi.co/v1/transactions/{externalPaymentId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to check payment status");
            }

            var responseData = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            var transactionStatus = responseData?["data"]?["status"]?.ToString();

            return Enum.TryParse(transactionStatus, true, out PaymentStatusEnum status) ? status : PaymentStatusEnum.Pending;
        }

        private bool ValidateSignature(string payload, string signature)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_privateKey));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            var computedSignature = BitConverter.ToString(computedHash).Replace("-", string.Empty).ToLower();
            return computedSignature == signature;
        }
    }
}
