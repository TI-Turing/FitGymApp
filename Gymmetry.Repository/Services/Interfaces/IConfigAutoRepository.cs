using System.Threading.Tasks;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IConfigAutoRepository
    {
        Task UpdateUsdPricesAsync(decimal usdToCopRate);
    }
}
