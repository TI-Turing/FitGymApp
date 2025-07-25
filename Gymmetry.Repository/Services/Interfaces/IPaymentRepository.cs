using System.Threading.Tasks;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IPaymentRepository
    {
        Task<ApplicationResponse<bool>> ProcessPaymentAsync(PaymentRequestDto paymentRequest);
    }
}