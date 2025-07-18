using System.Threading.Tasks;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IGymUserService
    {
        Task NullifyGymIdForExpiredPlansAsync();
    }
}