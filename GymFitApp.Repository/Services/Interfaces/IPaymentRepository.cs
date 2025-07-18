using System.Threading.Tasks;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IPaymentRepository
    {
        Task<ApplicationResponse<bool>> ProcessPaymentAsync(PaymentRequestDto paymentRequest);
    }
}