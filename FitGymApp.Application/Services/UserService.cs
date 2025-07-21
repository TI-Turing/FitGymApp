using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace FitGymApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly ILogger<UserService> _logger;
        private readonly IGymRepository _gymRepository;

        public UserService(IUserRepository userRepository, IPasswordService passwordService, ILogChangeService logChangeService, ILogErrorService logErrorService, ILogger<UserService> logger, IGymRepository gymRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _logger = logger;
            _gymRepository = gymRepository;
        }

        public async Task<ApplicationResponse<User>> CreateUserAsync(AddRequest request)
        {
            _logger.LogInformation("Starting CreateUserAsync method.");
            try
            {
                // Validate password rules before creating user
                if (_passwordService is FitGymApp.Application.Services.PasswordService passwordServiceImpl)
                {
                    var passwordValidation = passwordServiceImpl.ValidatePassword(request.Password, request.Email);
                    if (!passwordValidation.Success)
                    {
                        _logger.LogWarning("Password validation failed for email: {Email}", request.Email);
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
                    _logger.LogWarning("Email already registered: {Email}", request.Email);
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
                    _logger.LogError("Password hashing failed for email: {Email}", request.Email);
                    return new ApplicationResponse<User>
                    {
                        Success = false,
                        Message = hashResult.Message ?? "Technical error while hashing the password.",
                        ErrorCode = hashResult.ErrorCode ?? "HashError"
                    };
                }

                var user = new User
                {
                    Email = request.Email,
                    Password = hashResult.Data,
                };
                var created = await _userRepository.CreateUserAsync(user);
                _logger.LogInformation("User created successfully with ID: {UserId}", created.Id);
                return new ApplicationResponse<User>
                {
                    Success = true,
                    Message = "User created successfully.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a user.");
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
            _logger.LogInformation("Starting GetUserByIdAsync method for UserId: {UserId}", id);
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    _logger.LogWarning("User not found for UserId: {UserId}", id);
                    return new ApplicationResponse<User>
                    {
                        Success = false,
                        Message = "User not found.",
                        ErrorCode = "NotFound"
                    };
                }
                _logger.LogInformation("User retrieved successfully for UserId: {UserId}", id);
                return new ApplicationResponse<User>
                {
                    Success = true,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user with UserId: {UserId}", id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<User>
                {
                    Success = false,
                    Message = "Technical error while retrieving the user.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<User>>> GetAllUsersAsync()
        {
            _logger.LogInformation("Starting GetAllUsersAsync method.");
            try
            {
                var users = await _userRepository.GetAllUsersAsync();
                _logger.LogInformation("Retrieved {UserCount} users successfully.", users.Count());
                return new ApplicationResponse<IEnumerable<User>>
                {
                    Success = true,
                    Data = users
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<IEnumerable<User>>
                {
                    Success = false,
                    Message = "Technical error while retrieving users.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateUserAsync(UpdateRequest request, string ip ="", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateUserAsync method for UserId: {UserId}", request.Id);
            try
            {
                var userBefore = await _userRepository.GetUserByIdAsync(request.Id);
                if (userBefore == null)
                {
                    _logger.LogWarning("User not found for UserId: {UserId}", request.Id);
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
                    _logger.LogWarning("Password update is not allowed for UserId: {UserId}", request.Id);
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
                    IdEps = request.IdEps.HasValue ? request.IdEps.Value : userBefore.IdEps,
                    Name = request.Name ?? userBefore.Name,
                    LastName = request.LastName ?? userBefore.LastName,
                    UserName = request.UserName ?? userBefore.UserName,
                    IdGender = request.IdGender.HasValue ? request.IdGender.Value : userBefore.IdGender,
                    BirthDate = request.BirthDate ?? userBefore.BirthDate,
                    DocumentTypeId = request.DocumentTypeId.HasValue ? request.DocumentTypeId.Value : userBefore.DocumentTypeId,
                    DocumentType = request.DocumentType ?? userBefore.DocumentType,
                    Phone = request.Phone ?? userBefore.Phone,
                    CountryId = request.CountryId.HasValue ? request.CountryId.Value : userBefore.CountryId,
                    Address = request.Address ?? userBefore.Address,
                    CityId = request.CityId.HasValue ? request.CityId.Value : userBefore.CityId,
                    RegionId = request.RegionId ?? userBefore.RegionId,
                    Rh = request.Rh ?? userBefore.Rh,
                    EmergencyName = request.EmergencyName ?? userBefore.EmergencyName,
                    EmergencyPhone = request.EmergencyPhone ?? userBefore.EmergencyPhone,
                    PhysicalExceptions = request.PhysicalExceptions ?? userBefore.PhysicalExceptions,
                    IsActive = request.IsActive.HasValue ? request.IsActive.Value : userBefore.IsActive,
                    UserTypeId = request.UserTypeId ?? userBefore.UserTypeId,
                    Email = userBefore.Email,
                    Password = userBefore.Password
                };
                var updated = await _userRepository.UpdateUserAsync(user);
                if (updated)
                {
                    _logger.LogInformation("User updated successfully for UserId: {UserId}", request.Id);
                    await _logChangeService.LogChangeAsync("User", userBefore, user.Id, "", invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "User updated successfully."
                    };
                }
                else
                {
                    _logger.LogWarning("Could not update the user for UserId: {UserId}", request.Id);
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
                _logger.LogError(ex, "An error occurred while updating user with UserId: {UserId}", request.Id);
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

        private async Task<ApplicationResponse<bool>> ValidateUpdateUserGymRulesAsync(Guid userId, Guid gymId)
        {
            // Check if the user exists and is active
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null || user.IsActive != true)
            {
                _logger.LogWarning("User is either not found or inactive for UserId: {UserId}", userId);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User is either not found or inactive.",
                    ErrorCode = "UserInactiveOrNotFound"
                };
            }

            // Check if the gym exists and is active
            var gym = await _gymRepository.GetGymByIdAsync(gymId);
            if (gym == null || gym.IsActive != true)
            {
                _logger.LogWarning("Gym is either not found or inactive for GymId: {GymId}", gymId);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Gym is either not found or inactive.",
                    ErrorCode = "GymInactiveOrNotFound"
                };
            }

            // Check if the gym has an active GymPlanSelected
            var activeGymPlanSelected = gym.GymPlanSelecteds?.Any(plan => plan.IsActive);
            if (activeGymPlanSelected != true)
            {
                _logger.LogWarning("Gym does not have an active GymPlanSelected for GymId: {GymId}", gymId);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Gym does not have an active GymPlanSelected.",
                    ErrorCode = "NoActiveGymPlanSelected"
                };
            }

            return new ApplicationResponse<bool>
            {
                Success = true,
                Data = true
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateUserGymAsync(Guid userId, Guid gymId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateUserGymAsync method for UserId: {UserId} and GymId: {GymId}", userId, gymId);

            // Validate rules
            var validationResponse = await ValidateUpdateUserGymRulesAsync(userId, gymId);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }

            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                user.GymUserId = gymId;
                var updated = await _userRepository.UpdateUserAsync(user);
                if (updated)
                {
                    //TODO: Generar orden de pago.
                    _logger.LogInformation("GymUserId updated successfully for UserId: {UserId}", userId);
                    await _logChangeService.LogChangeAsync("User.GymUserId", user, user.Id, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "GymUserId updated successfully."
                    };
                }
                else
                {
                    _logger.LogWarning("Could not update GymUserId for UserId: {UserId}", userId);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Could not update GymUserId.",
                        ErrorCode = "UpdateFailed"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating GymUserId for UserId: {UserId}", userId);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while updating GymUserId.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteUserAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteUserAsync method for UserId: {UserId}", id);
            try
            {
                var deleted = await _userRepository.DeleteUserAsync(id);
                if (deleted)
                {
                    _logger.LogInformation("User deleted successfully for UserId: {UserId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "User deleted successfully."
                    };
                }
                else
                {
                    _logger.LogWarning("User not found or already deleted for UserId: {UserId}", id);
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
                _logger.LogError(ex, "An error occurred while deleting user with UserId: {UserId}", id);
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

        public async Task<ApplicationResponse<bool>> UpdatePasswordAsync(PasswordUserRequest request, string invocationId = "")
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

        public async Task<ApplicationResponse<bool>> UpdateUsersGymToNullAsync(Guid gymId, string ip="", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateUsersGymToNullAsync method for GymId: {GymId}", gymId);
            try
            {
                var userFilters = new Dictionary<string, object> { { "GymId", gymId } };
                var users = await _userRepository.FindUsersByFieldsAsync(userFilters);

                if (users.Any())
                {
                    var userIds = users.Select(user => user.Id).ToList();
                    var updateResult = await _userRepository.BulkUpdateFieldAsync(userIds, "GymId", null);

                    if (!updateResult)
                    {
                        _logger.LogWarning("Failed to update GymId to null for users in GymId: {GymId}", gymId);
                        return new ApplicationResponse<bool>
                        {
                            Success = false,
                            Data = false,
                            Message = "Failed to update users' GymId to null.",
                            ErrorCode = "UpdateFailed"
                        };
                    }

                    _logger.LogInformation("GymId set to null for {UserCount} users in GymId: {GymId}", users.Count(), gymId);
                    await _logChangeService.LogChangeAsync("User.GymId", users, null, "", invocationId);
                }

                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Users' GymId updated to null successfully."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating users' GymId to null for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while updating users' GymId to null.",
                    ErrorCode = "TechnicalError"
                };
            }
        }
    }
}
