using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.Gym.Request;
using Gymmetry.Domain.DTO.Gym.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Repository.Services.Interfaces;
using Microsoft.Extensions.Logging;
using QRCoder;

namespace Gymmetry.Application.Services
{
    public class GymService : IGymService
    {
        private readonly IGymRepository _gymRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IBranchService _branchService;
        private readonly IRoutineTemplateService _routineTemplateService;
        private readonly IUserService _userService;
        private readonly ILogger<GymService> _logger;

        public GymService(
            IGymRepository gymRepository,
            ILogChangeService logChangeService,
            ILogErrorService logErrorService,
            IMapper mapper,
            IUserRepository userRepository,
            IPlanRepository planRepository,
            IBranchService branchService,
            IRoutineTemplateService routineTemplateService,
            IUserService userService,
            ILogger<GymService> logger)
        {
            _gymRepository = gymRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
            _userRepository = userRepository;
            _planRepository = planRepository;
            _branchService = branchService;
            _routineTemplateService = routineTemplateService;
            _userService = userService;
            _logger = logger;
        }

        public async Task<ApplicationResponse<Gym>> CreateGymAsync(AddGymRequest request)
        {
            _logger.LogInformation("Starting CreateGymAsync method.");
            try
            {
                var entity = _mapper.Map<Gym>(request);
                var created = await _gymRepository.CreateGymAsync(entity).ConfigureAwait(false);
                _logger.LogInformation("Gym created successfully with ID: {GymId}", created.Id);
                return new ApplicationResponse<Gym>
                {
                    Success = true,
                    Message = "Gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a gym.");
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<Gym>
                {
                    Success = false,
                    Message = "Error técnico al crear el gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Gym>> GetGymByIdAsync(Guid id)
        {
            _logger.LogInformation("Starting GetGymByIdAsync method for GymId: {GymId}", id);
            try
            {
                var entity = await _gymRepository.GetGymByIdAsync(id).ConfigureAwait(false);
                if (entity == null)
                {
                    _logger.LogWarning("Gym not found for GymId: {GymId}", id);
                    return new ApplicationResponse<Gym>
                    {
                        Success = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                _logger.LogInformation("Gym retrieved successfully for GymId: {GymId}", id);
                return new ApplicationResponse<Gym>
                {
                    Success = true,
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving gym with GymId: {GymId}", id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<Gym>
                {
                    Success = false,
                    Message = "Error técnico al obtener el gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Gym>>> GetAllGymsAsync()
        {
            _logger.LogInformation("Starting GetAllGymsAsync method.");
            try
            {
                var entities = await _gymRepository.GetAllGymsAsync().ConfigureAwait(false);
                _logger.LogInformation("Retrieved {GymCount} gyms successfully.", entities.Count());
                return new ApplicationResponse<IEnumerable<Gym>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all gyms.");
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<IEnumerable<Gym>>
                {
                    Success = false,
                    Message = "Error técnico al obtener los gimnasios.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateGymAsync(UpdateGymRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateGymAsync method for GymId: {GymId}", request.Id);
            try
            {
                var before = await _gymRepository.GetGymByIdAsync(request.Id).ConfigureAwait(false);
                if (before == null)
                {
                    _logger.LogWarning("Gym not found for GymId: {GymId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var entity = _mapper.Map<Gym>(request);
                var updated = await _gymRepository.UpdateGymAsync(entity).ConfigureAwait(false);
                if (updated)
                {
                    _logger.LogInformation("Gym updated successfully for GymId: {GymId}", request.Id);
                    await _logChangeService.LogChangeAsync("Gym", before, userId, ip, invocationId).ConfigureAwait(false);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Gimnasio actualizado correctamente."
                    };
                }
                _logger.LogWarning("Could not update gym for GymId: {GymId}", request.Id);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "No se pudo actualizar el gimnasio.",
                    ErrorCode = "UpdateFailed"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating gym with GymId: {GymId}", request.Id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar el gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteGymAsync method for GymId: {GymId}", id);
            try
            {
                if (!await CanDeleteGymAsync(id).ConfigureAwait(false))
                {
                    _logger.LogWarning("Cannot delete gym with active related entities for GymId: {GymId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Cannot delete gym because it has active related entities.",
                        ErrorCode = "ValidationFailed"
                    };
                }
                var updateUsersResponse = await _userService.UpdateUsersGymToNullAsync(id).ConfigureAwait(false);
                if (!updateUsersResponse.Success)
                {
                    _logger.LogWarning("Failed to update users' GymId to null for GymId: {GymId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Failed to update users' GymId to null.",
                        ErrorCode = "UpdateFailed"
                    };
                }
                var deleteBranchesResponse = await _branchService.DeleteBranchesByGymIdAsync(id).ConfigureAwait(false);
                if (!deleteBranchesResponse.Success)
                {
                    _logger.LogWarning("Failed to delete branches for GymId: {GymId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Failed to delete branches.",
                        ErrorCode = "DeleteFailed"
                    };
                }
                var deleteRoutineTemplatesResponse = await _routineTemplateService.DeleteRoutineTemplatesByGymIdAsync(id).ConfigureAwait(false);
                if (!deleteRoutineTemplatesResponse.Success)
                {
                    _logger.LogWarning("Failed to delete routine templates for GymId: {GymId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Failed to delete routine templates.",
                        ErrorCode = "DeleteFailed"
                    };
                }
                var deleted = await _gymRepository.DeleteGymAsync(id).ConfigureAwait(false);
                if (deleted)
                {
                    _logger.LogInformation("Gym deleted successfully for GymId: {GymId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Gym deleted successfully."
                    };
                }
                _logger.LogWarning("Gym not found or already deleted for GymId: {GymId}", id);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Gym not found or already deleted.",
                    ErrorCode = "NotFound"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting gym with GymId: {GymId}", id);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Technical error while deleting the gym.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Gym>>> FindGymsByFieldsAsync(Dictionary<string, object> filters)
        {
            _logger.LogInformation("Starting FindGymsByFieldsAsync method with filters: {Filters}", filters);
            try
            {
                var entities = await _gymRepository.FindGymsByFieldsAsync(filters).ConfigureAwait(false);
                _logger.LogInformation("Retrieved {GymCount} gyms successfully with filters.", entities.Count());
                return new ApplicationResponse<IEnumerable<Gym>>
                {
                    Success = true,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while finding gyms with filters: {Filters}", filters);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<IEnumerable<Gym>>
                {
                    Success = false,
                    Message = "Error técnico al buscar los gimnasios.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<byte[]>> GenerateGymQrAsync(Guid gymId)
        {
            _logger.LogInformation("Starting GenerateGymQrAsync method for GymId: {GymId}", gymId);
            try
            {
                var gym = await _gymRepository.GetGymByIdAsync(gymId).ConfigureAwait(false);
                if (gym == null)
                {
                    _logger.LogWarning("Gym not found for GymId: {GymId}", gymId);
                    return new ApplicationResponse<byte[]>
                    {
                        Success = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var qrCodeImage = GenerateQrCode(gymId.ToString());
                _logger.LogInformation("QR code generated successfully for GymId: {GymId}", gymId);
                return new ApplicationResponse<byte[]>
                {
                    Success = true,
                    Data = qrCodeImage,
                    Message = "QR generado correctamente."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating QR code for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<byte[]>
                {
                    Success = false,
                    Message = "Error técnico al generar el QR.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GenerateGymQrResponse>> GenerateGymQrWithPlanTypeAsync(Guid gymId, string baseUrl)
        {
            _logger.LogInformation("Starting GenerateGymQrWithPlanTypeAsync method for GymId: {GymId}", gymId);
            if (baseUrl.EndsWith("/")) baseUrl = baseUrl.TrimEnd('/');
            try
            {
                var gym = await _gymRepository.GetGymByIdAsync(gymId).ConfigureAwait(false);
                if (gym == null)
                {
                    _logger.LogWarning("Gym not found for GymId: {GymId}", gymId);
                    return new ApplicationResponse<GenerateGymQrResponse>
                    {
                        Success = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var gymPlanSelected = gym.GymPlanSelecteds?.OrderByDescending(gps => gps.CreatedAt).FirstOrDefault();
                if (gymPlanSelected == null)
                {
                    _logger.LogWarning("No gym plan selected found for GymId: {GymId}", gymId);
                    return new ApplicationResponse<GenerateGymQrResponse>
                    {
                        Success = false,
                        Message = "Plan seleccionado de gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var gymPlanSelectedType = gymPlanSelected.GymPlanSelectedType;
                if (gymPlanSelectedType == null)
                {
                    _logger.LogWarning("No gym plan selected type found for GymId: {GymId}", gymId);
                    return new ApplicationResponse<GenerateGymQrResponse>
                    {
                        Success = false,
                        Message = "Tipo de plan seleccionado de gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var qrContent = $"{baseUrl}/{gymId}";
                var qrCodeImage = await GenerateQrCodeWithLogoAsync(qrContent, gymId).ConfigureAwait(false);
                var response = new GenerateGymQrResponse
                {
                    QrCode = Convert.ToBase64String(qrCodeImage),
                    GymPlanSelectedType = gymPlanSelectedType
                };
                _logger.LogInformation("QR code and plan type generated successfully for GymId: {GymId}", gymId);
                return new ApplicationResponse<GenerateGymQrResponse>
                {
                    Success = true,
                    Data = response,
                    Message = "QR y tipo de plan seleccionado generados correctamente."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating QR code and plan type for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<GenerateGymQrResponse>
                {
                    Success = false,
                    Message = "Error técnico al generar el QR y tipo de plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        private byte[] GenerateQrCode(string content)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            using var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        private async Task<byte[]> GenerateQrCodeWithLogoAsync(string content, Guid gymId)
        {
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            string? logoPath = await TryGetLogoPathAsync(gymId).ConfigureAwait(false);
            if (!string.IsNullOrEmpty(logoPath) && File.Exists(logoPath))
            {
                using var logo = (Bitmap)Image.FromFile(logoPath);
                return new PngByteQRCode(qrCodeData).GetGraphic(20, Color.Black, Color.White);
            }
            return new PngByteQRCode(qrCodeData).GetGraphic(20);
        }

        private async Task<string?> TryGetLogoPathAsync(Guid gymId)
        {
            try
            {
                var logoPath = await _gymRepository.GetLogoFromBlobStorageAsync(gymId).ConfigureAwait(false);
                if (!string.IsNullOrEmpty(logoPath))
                    return logoPath;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to fetch logo from blob storage for GymId: {GymId}", gymId);
            }
            return Environment.GetEnvironmentVariable("LocalLogoPath");
        }

        private bool ValidateImageSize(byte[] image, int maxBytes = 2 * 1024 * 1024)
        {
            return image.Length <= maxBytes;
        }

        public async Task<ApplicationResponse<string>> UploadGymLogoAsync(UploadGymLogoRequest request)
        {
            _logger.LogInformation("Starting UploadGymLogoAsync method for GymId: {GymId}", request.GymId);
            try
            {
                if (!ValidateImageSize(request.Image))
                {
                    _logger.LogWarning("Image size exceeds the maximum allowed size for GymId: {GymId}", request.GymId);
                    return new ApplicationResponse<string>
                    {
                        Success = false,
                        Message = "La imagen supera el tamaño máximo permitido de 2MB.",
                        ErrorCode = "ImageTooLarge"
                    };
                }
                var gym = await _gymRepository.GetGymByIdAsync(request.GymId).ConfigureAwait(false);
                if (gym == null)
                {
                    _logger.LogWarning("Gym not found for GymId: {GymId}", request.GymId);
                    return new ApplicationResponse<string>
                    {
                        Success = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                var url = await _gymRepository.UploadGymLogoAsync(request.GymId, request.Image, request.FileName, request.ContentType).ConfigureAwait(false);
                if (string.IsNullOrEmpty(url))
                {
                    _logger.LogWarning("Failed to upload logo for GymId: {GymId}", request.GymId);
                    return new ApplicationResponse<string>
                    {
                        Success = false,
                        Message = "No se pudo subir la imagen.",
                        ErrorCode = "UploadFailed"
                    };
                }
                _logger.LogInformation("Logo uploaded successfully for GymId: {GymId}", request.GymId);
                return new ApplicationResponse<string>
                {
                    Success = true,
                    Message = "Logo actualizado correctamente.",
                    Data = url
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading logo for GymId: {GymId}", request.GymId);
                await _logErrorService.LogErrorAsync(ex).ConfigureAwait(false);
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Error técnico al subir el logo.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<bool> CanDeleteGymAsync(Guid gymId)
        {
            var planFilters = new Dictionary<string, object> { { "GymId", gymId } };
            var plans = await _planRepository.FindPlansByFieldsAsync(planFilters).ConfigureAwait(false);
            return !plans.Any(plan => plan.IsActive);
        }
    }
}
