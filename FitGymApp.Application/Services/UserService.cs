using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<User>> CreateUserAsync(AddRequest request)
        {
            // Validate password rules before creating user
            if (_passwordService is FitGymApp.Application.Services.PasswordService passwordServiceImpl)
            {
                var passwordValidation = passwordServiceImpl.ValidatePassword(request.Password, request.Email);
                if (!passwordValidation.Success)
                {
                    return new ApplicationResponse<User>
                    {
                        Success = false,
                        Message = passwordValidation.Message,
                        ErrorCode = passwordValidation.ErrorCode
                    };
                }
            }

            var existingUsers = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "Email", request.Email } });
            if (existingUsers != null && existingUsers.Any())
            {
                return new ApplicationResponse<User>
                {
                    Success = false,
                    Message = "The email is already registered.",
                    ErrorCode = "EmailExists"
                };
            }
            var hashResult = await _passwordService.HashPasswordAsync(request.Password);
            if (!hashResult.Success)
            {
                return new ApplicationResponse<User>
                {
                    Success = false,
                    Message = hashResult.Message ?? "Technical error while hashing the password.",
                    ErrorCode = hashResult.ErrorCode ?? "HashError"
                };
            }
            try
            {
                var user = new User
                {
                    Email = request.Email,
                    Password = hashResult.Data,
                };
                var created = await _userRepository.CreateUserAsync(user);
                return new ApplicationResponse<User>
                {
                    Success = true,
                    Message = "User created successfully.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<User>
                {
                    Success = false,
                    Message = "Technical error while creating the user.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<User>> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApplicationResponse<User>
                {
                    Success = false,
                    Message = "User not found.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<User>
            {
                Success = true,
                Data = user
            };
        }

        public async Task<ApplicationResponse<IEnumerable<User>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return new ApplicationResponse<IEnumerable<User>>
            {
                Success = true,
                Data = users
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateUserAsync(UpdateRequest request)
        {
            try
            {
                var userBefore = await _userRepository.GetUserByIdAsync(request.Id);
                if (userBefore == null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "User not found.",
                        ErrorCode = "NotFound"
                    };
                }

                // RULE: If UpdateRequest model contains Password, reject the operation
                var updateRequestType = request.GetType();
                var passwordProp = updateRequestType.GetProperty("Password");
                if (passwordProp != null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Password update is not allowed from this method.",
                        ErrorCode = "PasswordUpdateNotAllowed"
                    };
                }

                // Nueva regla: No permitir actualizar GymUserId desde este método
                var gymUserIdProp = updateRequestType.GetProperty("GymUserId");
                if (gymUserIdProp != null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No está permitido actualizar el campo GymUserId desde este método.",
                        ErrorCode = "GymUserIdUpdateNotAllowed"
                    };
                }

                var user = new User
                {
                    Id = request.Id,
                    IdEps = request.IdEps,
                    Name = request.Name,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    IdGender = request.IdGender,
                    BirthDate = request.BirthDate,
                    DocumentTypeId = request.DocumentTypeId,
                    DocumentType = request.DocumentType,
                    Phone = request.Phone,
                    CountryId = request.CountryId,
                    Address = request.Address,
                    CityId = request.CityId,
                    RegionId = request.RegionId,
                    Rh = request.Rh,
                    EmergencyName = request.EmergencyName,
                    EmergencyPhone = request.EmergencyPhone,
                    PhysicalExceptions = request.PhysicalExceptions,
                    IsActive = request.IsActive,
                    UserTypeId = request.UserTypeId,
                    Email = userBefore?.Email ?? string.Empty,
                    Password = userBefore?.Password ?? string.Empty
                };
                var updated = await _userRepository.UpdateUserAsync(user);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("User", userBefore, user.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "User updated successfully."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Could not update the user (not found or inactive).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while updating the user.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        // Nuevo método para actualizar GymUserId
        public async Task<ApplicationResponse<bool>> UpdateUserGymAsync(Guid userId, Guid gymId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                if (user == null)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "User not found.",
                        ErrorCode = "NotFound"
                    };
                }
                user.GymUserId = gymId;
                var updated = await _userRepository.UpdateUserAsync(user);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("User.GymUserId", user, user.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "GymUserId actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el usuario.",
                        ErrorCode = "UpdateFailed"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar GymUserId.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteUserAsync(Guid id)
        {
            try
            {
                var deleted = await _userRepository.DeleteUserAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "User deleted successfully."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "User not found or already deleted.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while deleting the user.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<User>>> FindUsersByFieldsAsync(Dictionary<string, object> filters)
        {
            var users = await _userRepository.FindUsersByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<User>>
            {
                Success = true,
                Data = users
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePasswordAsync(PasswordUserRequest request)
        {
            // Validate user existence
            var users = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "Email", request.Email } });
            var user = users?.FirstOrDefault();
            if (user == null)
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User not found.",
                    ErrorCode = "NotFound"
                };
            }

            // Validate new password rules
            var passwordValidation = _passwordService.ValidatePassword(request.NewPassword, request.Email);
            if (!passwordValidation.Success)
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = passwordValidation.Message,
                    ErrorCode = passwordValidation.ErrorCode
                };
            }
            // Hash and update password
            var hashResult = await _passwordService.HashPasswordAsync(request.NewPassword);
            if (!hashResult.Success)
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = hashResult.Message,
                    ErrorCode = hashResult.ErrorCode
                };
            }
            user.Password = hashResult.Data;
            var updated = await _userRepository.UpdateUserAsync(user);
            if (updated)
            {
                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Password updated successfully."
                };
            }
            else
            {
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Could not update the password.",
                    ErrorCode = "UpdateFailed"
                };
            }
        }
    }
}
