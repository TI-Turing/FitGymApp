using System.Threading.Tasks;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<ApplicationResponse<bool>> ValidatePaymentAsync(PaymentRequestDto paymentRequest);
        Task<ApplicationResponse<bool>> ProcessPaymentAsync(PaymentRequestDto paymentRequest);
    }
}