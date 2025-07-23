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

namespace FitGymApp.Functions.UserFunctions
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

        [Function("User_ValidateOtpFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/validate-otp")] HttpRequestData req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var request = JsonConvert.DeserializeObject<ValidateOtpRequest>(requestBody);
            if (request == null || request.UserId == Guid.Empty || string.IsNullOrEmpty(request.Otp))
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Datos de entrada inválidos.",
                    Data = false,
                    StatusCode = 400
                });
                return badResponse;
            }
            var isValid = await _userOtpService.ValidateOtpAsync(request.UserId, request.Otp);
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new ApiResponse<bool>
            {
                Success = isValid,
                Message = isValid ? "OTP válido." : "OTP inválido o expirado.",
                Data = isValid,
                StatusCode = isValid ? 200 : 400
            });
            return response;
        }
    }
}
