using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using Gymmetry.Repository.Services.Interfaces;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogLoginService _logLoginService;
        private readonly ILogErrorService _logErrorService;

        public AuthService(IAuthRepository authRepository, IUserRepository userRepository, IPasswordService passwordService, ILogLoginService logLoginService, ILogErrorService logErrorService)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logLoginService = logLoginService;
            _logErrorService = logErrorService;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request, string ip)
        {
            try
            {
                var users = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "Email", request.UserNameOrEmail } });
                var user = users.FirstOrDefault();
                if (user == null)
                {
                    users = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "UserName", request.UserNameOrEmail } });
                    user = users.FirstOrDefault();
                }
                if (user == null)
                {
                    return null;
                }

                var verifyResult = await _passwordService.VerifyPasswordAsync(request.Password, user.Password);
                if (!verifyResult.Success || !verifyResult.Data)
                {
                    await _logLoginService.LogLoginAsync(user.Id, false, null, "Login fallido: password incorrecto");
                    return null;
                }
                request.Password = user.Password;
                var response = await _authRepository.LoginAsync(request);
                string refreshToken = Guid.NewGuid().ToString();
                DateTime refreshTokenExpiration = DateTime.UtcNow.AddMonths(6);
                if (response != null)
                {
                    response.Token = await JwtTokenGenerator.GenerateTokenAsync(response.UserId, response.UserName, response.Email);
                    response.RefreshToken= refreshToken;
                    response.TokenExpiration = DateTime.UtcNow.AddHours(1);
                    response.RefreshTokenExpiration = refreshTokenExpiration;
                    var logLogin = _logLoginService.GetLogLoginByUserId(response.UserId).Result.Data;
                    if (logLogin != null)
                    {
                        logLogin.IsActive = false;
                        await _logLoginService.UpdateLogLoginAsync(logLogin);
                    }
                    await _logLoginService.LogLoginAsync(response.UserId, true, refreshToken, refreshTokenExpiration, ip, "Login exitoso");
                }
                else
                {
                    await _logLoginService.LogLoginAsync(user.Id, false, ip, "Login fallido: usuario inactivo o error en repositorio");
                }
                user.LogLogins=  new List<LogLogin>();
                response.User = user;

                return response;
            }
            catch (Exception ex)
            {
                await _logLoginService.LogLoginAsync(null, false, null, "Login fallido: excepción interna");
                await _logErrorService.LogErrorAsync(ex);
                return null;
            }
        }

        public async Task<ApplicationResponse<RefreshTokenResponse>> RefreshTokenAsync(RefreshTokenRequest request)
        {
            // Permitir access token vencido, solo validar formato y firma
            if (!string.IsNullOrEmpty(request.Token))
            {
                Guid userId;
                try
                {
                    var principal = await JwtTokenGenerator.ValidateTokenIgnoreExpirationAsync(request.Token);
                    var subClaim = principal?.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)
                        ?? principal?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                    if (subClaim == null || !Guid.TryParse(subClaim.Value, out userId))
                        return null;
                }
                catch
                {
                    return null;
                }
                // Consultar el usuario por id
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                    return null;

                var logLogin = _logLoginService.GetLogLoginByUserId(userId).Result;
                string newToken = string.Empty;
                // Validar refresh token y expiración
                if (logLogin.Data?.RefreshToken == request.RefreshToken && logLogin.Data?.RefreshTokenExpiration > DateTime.UtcNow)
                {
                    newToken = await JwtTokenGenerator.GenerateTokenAsync(user.Id, user.UserName ?? user.Email, user.Email, 60);
                    return new ApplicationResponse<RefreshTokenResponse>
                    {
                        Success = true,
                        Message = "Token refrescado correctamente.",
                        Data = new RefreshTokenResponse
                        {
                            NewToken = newToken,
                            TokenExpiration = DateTime.UtcNow.AddMinutes(60)
                        }
                    };
                }
                else
                {
                    return new ApplicationResponse<RefreshTokenResponse>
                    {
                        Success = false,
                        Message = "Refresh token inválido o expirado.",
                        Data = null
                    };
                }
            }
            return null;
        }
    }
}