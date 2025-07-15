using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Gym.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;
using QRCoder;
using System.Drawing;
using System.IO;
using FitGymApp.Domain.DTO.Gym.Response;

namespace FitGymApp.Application.Services
{
    public class GymService : IGymService
    {
        private readonly IGymRepository _gymRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;

        public GymService(IGymRepository gymRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper)
        {
            _gymRepository = gymRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
        }

        public async Task<ApplicationResponse<Gym>> CreateGymAsync(AddGymRequest request)
        {
            try
            {
                var entity = _mapper.Map<Gym>(request);
                var created = await _gymRepository.CreateGymAsync(entity);
                return new ApplicationResponse<Gym>
                {
                    Success = true,
                    Message = "Gimnasio creado correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
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
            var entity = await _gymRepository.GetGymByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<Gym>
                {
                    Success = false,
                    Message = "Gimnasio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<Gym>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<Gym>>> GetAllGymsAsync()
        {
            var entities = await _gymRepository.GetAllGymsAsync();
            return new ApplicationResponse<IEnumerable<Gym>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdateGymAsync(UpdateGymRequest request, Guid? userId, string invocationId = "")
        {
            try
            {
                var before = await _gymRepository.GetGymByIdAsync(request.Id);
                var entity = _mapper.Map<Gym>(request);
                var updated = await _gymRepository.UpdateGymAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("Gym", before, userId, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Gimnasio actualizado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar el gimnasio (no encontrado o inactivo).",
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
                    Message = "Error técnico al actualizar el gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteGymAsync(Guid id)
        {
            try
            {
                var deleted = await _gymRepository.DeleteGymAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Gimnasio eliminado correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Gimnasio no encontrado o ya eliminado.",
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
                    Message = "Error técnico al eliminar el gimnasio.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Gym>>> FindGymsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _gymRepository.FindGymsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<Gym>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<byte[]>> GenerateGymQrAsync(Guid gymId)
        {
            try
            {
                // Validar que el gym exista
                var gym = await _gymRepository.GetGymByIdAsync(gymId);
                if (gym == null)
                {
                    return new ApplicationResponse<byte[]>
                    {
                        Success = false,
                        Message = "Gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                // Generar QR usando PngByteQRCode
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrCodeData = qrGenerator.CreateQrCode(gymId.ToString(), QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    return new ApplicationResponse<byte[]>
                    {
                        Success = true,
                        Data = qrCodeImage,
                        Message = "QR generado correctamente."
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<byte[]>
                {
                    Success = false,
                    Message = "Error técnico al generar el QR.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<GenerateGymQrResponse>> GenerateGymQrWithPlanTypeAsync(Guid gymId)
        {
            try
            {
                var gym = await _gymRepository.GetGymByIdAsync(gymId);
                if (gym == null)
                {
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
                    return new ApplicationResponse<GenerateGymQrResponse>
                    {
                        Success = false,
                        Message = "Tipo de plan seleccionado de gimnasio no encontrado.",
                        ErrorCode = "NotFound"
                    };
                }
                // Generar QR
                using (var qrGenerator = new QRCodeGenerator())
                using (var qrCodeData = qrGenerator.CreateQrCode(gymId.ToString(), QRCodeGenerator.ECCLevel.Q))
                using (var qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeImage = qrCode.GetGraphic(20);
                    var response = new GenerateGymQrResponse
                    {
                        QrCode = qrCodeImage,
                        GymPlanSelectedType = gymPlanSelectedType
                    };
                    return new ApplicationResponse<GenerateGymQrResponse>
                    {
                        Success = true,
                        Data = response,
                        Message = "QR y tipo de plan seleccionado generados correctamente."
                    };
                }
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<GenerateGymQrResponse>
                {
                    Success = false,
                    Message = "Error técnico al generar el QR y tipo de plan.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        private bool ValidateImageSize(byte[] image, int maxBytes = 2 * 1024 * 1024)
        {
            return image.Length <= maxBytes;
        }

        public async Task<ApplicationResponse<string>> UploadGymLogoAsync(UploadGymLogoRequest request)
        {
            if (!ValidateImageSize(request.Image))
            {
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "La imagen supera el tamaño máximo permitido de 2MB.",
                    ErrorCode = "ImageTooLarge"
                };
            }
            var gym = await _gymRepository.GetGymByIdAsync(request.GymId);
            if (gym == null)
            {
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "Gimnasio no encontrado.",
                    ErrorCode = "NotFound"
                };
            }
            var url = await _gymRepository.UploadGymLogoAsync(request.GymId, request.Image, request.FileName, request.ContentType);
            if (string.IsNullOrEmpty(url))
            {
                return new ApplicationResponse<string>
                {
                    Success = false,
                    Message = "No se pudo subir la imagen.",
                    ErrorCode = "UploadFailed"
                };
            }
            return new ApplicationResponse<string>
            {
                Success = true,
                Message = "Logo actualizado correctamente.",
                Data = url
            };
        }
    }
}
