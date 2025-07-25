using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;

namespace Gymmetry.Repository.Services.Interfaces
{
    public interface IUserOtpRepository
    {
        Task<IEnumerable<UserOTP>> FindUserOtpByFieldsAsync(Dictionary<string, object> filters);
        Task<bool> UpdateUserOtpAsync(UserOTP entity);
        Task DeleteUserOtpsAsync(IEnumerable<UserOTP> otps);
    }
}
