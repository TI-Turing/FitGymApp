using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO;

namespace FitGymApp.Application.Services.Interfaces
{
    public interface IUserOtpService
    {
        Task<bool> ValidateOtpAsync(Guid userId, string otp);
        Task<bool> ValidateOtpAsync(Guid userId, string otp, string verificationType);
        Task<ApplicationResponse<string>> SendOtpAsync(Guid userId, string verificationType, string recipient, string method);
    }
}
