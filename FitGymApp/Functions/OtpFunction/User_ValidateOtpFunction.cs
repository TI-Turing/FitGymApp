using System.IO;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.DTO.User.Request;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace FitGymApp.Functions.OtpFunction
{
    public class User_ValidateOtpFunction
    {
        private readonly ILogger<User_ValidateOtpFunction> _logger;
        private readonly IUserOtpService _userOtpService;

        public User_ValidateOtpFunction(ILogger<User_ValidateOtpFunction> logger, IUserOtpService userOtpService)
        {
            _logger = logger;
            _userOtpService = userOtpService;
        }

        
    }
}
