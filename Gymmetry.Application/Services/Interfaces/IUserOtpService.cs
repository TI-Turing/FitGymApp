using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services.Interfaces
{
    public interface IUserOtpService
    {
        Task<bool> ValidateOtpAsync(Guid userId, string otp);
        Task<bool> ValidateOtpAsync(Guid userId, string otp, string verificationType);
        Task<ApplicationResponse<string>> SendOtpAsync(Guid userId, string verificationType, string recipient, string method);
    }
}
