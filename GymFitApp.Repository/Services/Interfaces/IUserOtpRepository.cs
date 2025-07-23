using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Services.Interfaces
{
    public interface IUserOtpRepository
    {
        Task<IEnumerable<UserOTP>> FindUserOtpByFieldsAsync(Dictionary<string, object> filters);
        Task<bool> UpdateUserOtpAsync(UserOTP entity);
    }
}
