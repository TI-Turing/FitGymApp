using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO.PhysicalAssessment.Request;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class PhysicalAssessmentService : IPhysicalAssessmentService
    {
        private readonly IPhysicalAssessmentRepository _physicalAssessmentRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;

        public PhysicalAssessmentService(IPhysicalAssessmentRepository physicalAssessmentRepository, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _physicalAssessmentRepository = physicalAssessmentRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }

        public async Task<ApplicationResponse<PhysicalAssessment>> CreatePhysicalAssessmentAsync(AddPhysicalAssessmentRequest request)
        {
            try
            {
                var entity = new PhysicalAssessment
                {
                    Height = request.Height,
                    Weight = request.Weight,
                    LeftArm = request.LeftArm,
                    RighArm = request.RighArm,
                    LeftForearm = request.LeftForearm,
                    RightForearm = request.RightForearm,
                    LeftThigh = request.LeftThigh,
                    RightThigh = request.RightThigh,
                    LeftCalf = request.LeftCalf,
                    RightCalf = request.RightCalf,
                    Abdomen = request.Abdomen,
                    Chest = request.Chest,
                    UpperBack = request.UpperBack,
                    LowerBack = request.LowerBack,
                    Neck = request.Neck,
                    Waist = request.Waist,
                    Hips = request.Hips,
                    Shoulders = request.Shoulders,
                    Wrist = request.Wrist,
                    BodyFatPercentage = request.BodyFatPercentage,
                    MuscleMass = request.MuscleMass,
                    Bmi = request.Bmi,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserId = request.UserId
                };
                var created = await _physicalAssessmentRepository.CreatePhysicalAssessmentAsync(entity);
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = true,
                    Message = "Evaluación física creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = false,
                    Message = "Error técnico al crear la evaluación física.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<PhysicalAssessment>> GetPhysicalAssessmentByIdAsync(Guid id)
        {
            var entity = await _physicalAssessmentRepository.GetPhysicalAssessmentByIdAsync(id);
            if (entity == null)
            {
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = false,
                    Message = "Evaluación física no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<PhysicalAssessment>
            {
                Success = true,
                Data = entity
            };
        }

        public async Task<ApplicationResponse<IEnumerable<PhysicalAssessment>>> GetAllPhysicalAssessmentsAsync()
        {
            var entities = await _physicalAssessmentRepository.GetAllPhysicalAssessmentsAsync();
            return new ApplicationResponse<IEnumerable<PhysicalAssessment>>
            {
                Success = true,
                Data = entities
            };
        }

        public async Task<ApplicationResponse<bool>> UpdatePhysicalAssessmentAsync(UpdatePhysicalAssessmentRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            try
            {
                var before = await _physicalAssessmentRepository.GetPhysicalAssessmentByIdAsync(request.Id);
                var entity = new PhysicalAssessment
                {
                    Id = request.Id,
                    Height = request.Height,
                    Weight = request.Weight,
                    LeftArm = request.LeftArm,
                    RighArm = request.RighArm,
                    LeftForearm = request.LeftForearm,
                    RightForearm = request.RightForearm,
                    LeftThigh = request.LeftThigh,
                    RightThigh = request.RightThigh,
                    LeftCalf = request.LeftCalf,
                    RightCalf = request.RightCalf,
                    Abdomen = request.Abdomen,
                    Chest = request.Chest,
                    UpperBack = request.UpperBack,
                    LowerBack = request.LowerBack,
                    Neck = request.Neck,
                    Waist = request.Waist,
                    Hips = request.Hips,
                    Shoulders = request.Shoulders,
                    Wrist = request.Wrist,
                    BodyFatPercentage = request.BodyFatPercentage,
                    MuscleMass = request.MuscleMass,
                    Bmi = request.Bmi,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    UserId = request.UserId
                };
                var updated = await _physicalAssessmentRepository.UpdatePhysicalAssessmentAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("PhysicalAssessment", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Evaluación física actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la evaluación física (no encontrada o inactiva).",
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
                    Message = "Error técnico al actualizar la evaluación física.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeletePhysicalAssessmentAsync(Guid id)
        {
            try
            {
                var deleted = await _physicalAssessmentRepository.DeletePhysicalAssessmentAsync(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Evaluación física eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Evaluación física no encontrada o ya eliminada.",
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
                    Message = "Error técnico al eliminar la evaluación física.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<PhysicalAssessment>>> FindPhysicalAssessmentsByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _physicalAssessmentRepository.FindPhysicalAssessmentsByFieldsAsync(filters);
            return new ApplicationResponse<IEnumerable<PhysicalAssessment>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
