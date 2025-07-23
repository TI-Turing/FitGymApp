using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.User.Request;
using FitGymApp.Domain.DTO.User.Response;
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
        private readonly IVerificationTypeRepository _verificationTypeRepository;

        public UserService(
            IUserRepository userRepository,
            IPasswordService passwordService,
            ILogChangeService logChangeService,
            ILogErrorService logErrorService,
            ILogger<UserService> logger,
            IGymRepository gymRepository,
            IVerificationTypeRepository verificationTypeRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _logger = logger;
            _gymRepository = gymRepository;
            _verificationTypeRepository = verificationTypeRepository;
        }

        public async Task<ApplicationResponse<User>> CreateUserAsync(AddRequest request)
        {
            _logger.LogInformation("Starting CreateUserAsync method.");
            try
            {
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

                var existingUsers = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "Email", request.Email } }).ConfigureAwait(false);
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

                var hashResult = await _passwordService.HashPasswordAsync(request.Password).ConfigureAwait(false);
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
                var created = await _userRepository.CreateUserAsync(user).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
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
                var user = await _userRepository.GetUserByIdAsync(id).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
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
                var users = await _userRepository.GetAllUsersAsync().ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<IEnumerable<User>>
                {
                    Success = false,
                    Message = "Technical error while retrieving users.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateUserAsync(UpdateRequest request, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateUserAsync method for UserId: {UserId}", request.Id);
            try
            {
                var userBefore = await _userRepository.GetUserByIdAsync(request.Id).ConfigureAwait(false);
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

                if (!string.IsNullOrEmpty(request.Phone))
                {
                    var phoneExists = await _userRepository.PhoneExistsAsync(request.Phone).ConfigureAwait(false);
                    if (phoneExists && userBefore.Phone != request.Phone)
                    {
                        return new ApplicationResponse<bool>
                        {
                            Success = false,
                            Data = false,
                            Message = "El teléfono ya está registrado.",
                            ErrorCode = "PhoneExists"
                        };
                    }
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
                    UserTypeId = request.UserTypeId ?? userBefore.UserTypeId,
                    Email = userBefore.Email,
                    Password = userBefore.Password,
                    IsActive = userBefore.IsActive,
                };
                user.RegistrationCompleted = await ValidateUserFieldsAsync(user).ConfigureAwait(false);

                var updated = await _userRepository.UpdateUserAsync(user).ConfigureAwait(false);
                if (updated)
                {
                    _logger.LogInformation("User updated successfully for UserId: {UserId}", request.Id);
                    await _logChangeService.LogChangeAsync("User", userBefore, user.Id, "", invocationId).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
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
            var user = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);
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

            var gym = await _gymRepository.GetGymByIdAsync(gymId).ConfigureAwait(false);
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

            var validationResponse = await ValidateUpdateUserGymRulesAsync(userId, gymId).ConfigureAwait(false);
            if (!validationResponse.Success)
            {
                return validationResponse;
            }

            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId).ConfigureAwait(false);
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

                if (gymId != Guid.Empty)
                {
                    user.GymUserId = gymId;
                }

                var updated = await _userRepository.UpdateUserAsync(user).ConfigureAwait(false);
                if (updated)
                {
                    _logger.LogInformation("GymUserId updated successfully for UserId: {UserId}", userId);
                    await _logChangeService.LogChangeAsync("User.GymUserId", user, user.Id, ip, invocationId).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
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
                var deleted = await _userRepository.DeleteUserAsync(id).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
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
            var users = await _userRepository.FindUsersByFieldsAsync(filters).ConfigureAwait(false);
            return new ApplicationResponse<IEnumerable<User>>
            {
                Success = true,
                Data = users
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePasswordAsync(PasswordUserRequest request, string invocationId = "")
        {
            var users = await _userRepository.FindUsersByFieldsAsync(new Dictionary<string, object> { { "Email", request.Email } }).ConfigureAwait(false);
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
            var hashResult = await _passwordService.HashPasswordAsync(request.NewPassword).ConfigureAwait(false);
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
            var updated = await _userRepository.UpdateUserAsync(user).ConfigureAwait(false);
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

        public async Task<ApplicationResponse<bool>> UpdateUsersGymToNullAsync(Guid gymId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateUsersGymToNullAsync method for GymId: {GymId}", gymId);
            try
            {
                var userFilters = new Dictionary<string, object> { { "GymId", gymId } };
                var users = await _userRepository.FindUsersByFieldsAsync(userFilters).ConfigureAwait(false);

                if (users.Any())
                {
                    var userIds = users.Select(user => user.Id).ToList();
                    var updateResult = await _userRepository.BulkUpdateFieldAsync(userIds, "GymId", null).ConfigureAwait(false);

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
                    await _logChangeService.LogChangeAsync("User.GymId", users, null, "", invocationId).ConfigureAwait(false);
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
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while updating users' GymId to null.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ValidateUserFieldsResponse> ValidateUserFieldsAsync(Guid userId)
        {
            var userResponse = await GetUserByIdAsync(userId).ConfigureAwait(false);
            if (!userResponse.Success || userResponse.Data == null)
            {
                return new ValidateUserFieldsResponse
                {
                    IsComplete = false,
                    MissingFields = new List<string> { "User not found" }
                };
            }

            var user = userResponse.Data;
            var missingFields = new List<string>();

            if (string.IsNullOrEmpty(user.Email)) missingFields.Add("Email");
            if (string.IsNullOrEmpty(user.Password)) missingFields.Add("Password");
            if (!user.IdEps.HasValue) missingFields.Add("IdEPS");
            if (string.IsNullOrEmpty(user.Name)) missingFields.Add("Name");
            if (string.IsNullOrEmpty(user.UserName)) missingFields.Add("UserName");
            if (!user.IdGender.HasValue) missingFields.Add("IdGender");
            if (!user.BirthDate.HasValue) missingFields.Add("BirthDate");
            if (string.IsNullOrEmpty(user.ProfileImageUrl)) missingFields.Add("ProfileImageUrl");
            if (!user.DocumentTypeId.HasValue) missingFields.Add("DocumentTypeId");
            if (string.IsNullOrEmpty(user.DocumentType)) missingFields.Add("DocumentType");
            if (string.IsNullOrEmpty(user.Phone)) missingFields.Add("Phone");
            if (!user.CountryId.HasValue) missingFields.Add("CountryId");
            if (string.IsNullOrEmpty(user.Address)) missingFields.Add("Address");
            if (!user.CityId.HasValue) missingFields.Add("CityId");
            if (!user.RegionId.HasValue) missingFields.Add("RegionId");
            if (string.IsNullOrEmpty(user.Rh)) missingFields.Add("RH");
            if (string.IsNullOrEmpty(user.EmergencyName)) missingFields.Add("EmergencyName");
            if (string.IsNullOrEmpty(user.EmergencyPhone)) missingFields.Add("EmergencyPhone");
            if (string.IsNullOrEmpty(user.PhysicalExceptions)) missingFields.Add("PhysicalExceptions");

            return new ValidateUserFieldsResponse
            {
                IsComplete = !missingFields.Any(),
                MissingFields = missingFields
            };
        }

        public async Task<bool> ValidateUserFieldsAsync(User user)
        {
            return !string.IsNullOrEmpty(user.Email) &&
                   !string.IsNullOrEmpty(user.Password) &&
                   user.IdEps.HasValue &&
                   !string.IsNullOrEmpty(user.Name) &&
                   !string.IsNullOrEmpty(user.UserName) &&
                   user.IdGender.HasValue &&
                   user.BirthDate.HasValue &&
                   !string.IsNullOrEmpty(user.ProfileImageUrl) &&
                   user.DocumentTypeId.HasValue &&
                   !string.IsNullOrEmpty(user.DocumentType) &&
                   !string.IsNullOrEmpty(user.Phone) &&
                   user.CountryId.HasValue &&
                   !string.IsNullOrEmpty(user.Address) &&
                   user.CityId.HasValue &&
                   user.RegionId.HasValue &&
                   !string.IsNullOrEmpty(user.Rh) &&
                   !string.IsNullOrEmpty(user.EmergencyName) &&
                   !string.IsNullOrEmpty(user.EmergencyPhone) &&
                   !string.IsNullOrEmpty(user.PhysicalExceptions);
        }

        public async Task<ApplicationResponse<string>> UploadUserProfileImageAsync(UploadUserProfileImageRequest request)
        {
            try
            {
                var uploadedUrl = await _userRepository.UploadUserProfileImageAsync(request.UserId, request.Image).ConfigureAwait(false);
                return new ApplicationResponse<string>
                {
                    Success = true,
                    Data = uploadedUrl,
                    Message = "Profile image uploaded successfully."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading the profile image for UserId: {UserId}", request.UserId);
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Technical error while uploading the profile image.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> PhoneExistsAsync(string phone)
        {
            var exists = await _userRepository.PhoneExistsAsync(phone).ConfigureAwait(false);
            return new ApplicationResponse<bool>
            {
                Success = true,
                Data = exists,
                Message = exists ? "Phone already exists." : "Phone does not exist."
            };
        }
    }
}
