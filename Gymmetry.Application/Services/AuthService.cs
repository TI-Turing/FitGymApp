using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.Auth.Request;
using Gymmetry.Domain.DTO.Auth.Response;
using Gymmetry.Repository.Services.Interfaces;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
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
                if (response != null)
                {
                    response.Token = await JwtTokenGenerator.GenerateTokenAsync(response.UserId, response.UserName, response.Email);
                    await _logLoginService.LogLoginAsync(response.UserId, true, null, "Login exitoso");
                }
                else
                {
                    await _logLoginService.LogLoginAsync(user.Id, false, null, "Login fallido: usuario inactivo o error en repositorio");
                }
                return response;
            }
            catch (Exception ex)
            {
                await _logLoginService.LogLoginAsync(null, false, null, "Login fallido: excepción interna");
                await _logErrorService.LogErrorAsync(ex);
                return null;
            }
        }

        public async Task<RefreshTokenResponse?> RefreshTokenAsync(RefreshTokenRequest request)
        {
            // Aquí deberías validar el refresh token y generar un nuevo JWT si es válido
            // Por simplicidad, solo se regenera el token si el refresh token es igual a "valid-refresh-token"
            if (request.RefreshToken == "valid-refresh-token")
            {
                // Aquí deberías obtener el usuario asociado al refresh token
                // Para ejemplo, se usan datos dummy
                var userId = Guid.NewGuid();
                var userName = "usuario";
                var email = "usuario@email.com";
                var newToken = await JwtTokenGenerator.GenerateTokenAsync(userId, userName, email);
                return await Task.FromResult(new RefreshTokenResponse
                {
                    Token = newToken,
                    RefreshToken = request.RefreshToken // En un caso real, deberías emitir un nuevo refresh token
                });
            }
            return await Task.FromResult<RefreshTokenResponse?>(null);
        }
    }
}