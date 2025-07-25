using System.Threading.Tasks;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IGymUserService
    {
        Task NullifyGymIdForExpiredPlansAsync();
    }
}