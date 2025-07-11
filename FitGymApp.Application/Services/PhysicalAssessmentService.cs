using System;
using System.Collections.Generic;
using System.Linq;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.PhysicalAssessment.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;

namespace FitGymApp.Application.Services
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

        public ApplicationResponse<PhysicalAssessment> CreatePhysicalAssessment(AddPhysicalAssessmentRequest request)
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
                var created = _physicalAssessmentRepository.CreatePhysicalAssessment(entity);
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = true,
                    Message = "Evaluaci�n f�sica creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = false,
                    Message = "Error t�cnico al crear la evaluaci�n f�sica.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<PhysicalAssessment> GetPhysicalAssessmentById(Guid id)
        {
            var entity = _physicalAssessmentRepository.GetPhysicalAssessmentById(id);
            if (entity == null)
            {
                return new ApplicationResponse<PhysicalAssessment>
                {
                    Success = false,
                    Message = "Evaluaci�n f�sica no encontrada.",
                    ErrorCode = "NotFound"
                };
            }
            return new ApplicationResponse<PhysicalAssessment>
            {
                Success = true,
                Data = entity
            };
        }

        public ApplicationResponse<IEnumerable<PhysicalAssessment>> GetAllPhysicalAssessments()
        {
            var entities = _physicalAssessmentRepository.GetAllPhysicalAssessments();
            return new ApplicationResponse<IEnumerable<PhysicalAssessment>>
            {
                Success = true,
                Data = entities
            };
        }

        public ApplicationResponse<bool> UpdatePhysicalAssessment(UpdatePhysicalAssessmentRequest request)
        {
            try
            {
                var before = _physicalAssessmentRepository.GetPhysicalAssessmentById(request.Id);
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
                var updated = _physicalAssessmentRepository.UpdatePhysicalAssessment(entity);
                if (updated)
                {
                    _logChangeService.LogChange("PhysicalAssessment", before, entity.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Evaluaci�n f�sica actualizada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la evaluaci�n f�sica (no encontrada o inactiva).",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error t�cnico al actualizar la evaluaci�n f�sica.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<bool> DeletePhysicalAssessment(Guid id)
        {
            try
            {
                var deleted = _physicalAssessmentRepository.DeletePhysicalAssessment(id);
                if (deleted)
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Evaluaci�n f�sica eliminada correctamente."
                    };
                }
                else
                {
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Evaluaci�n f�sica no encontrada o ya eliminada.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logErrorService.LogError(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error t�cnico al eliminar la evaluaci�n f�sica.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public ApplicationResponse<IEnumerable<PhysicalAssessment>> FindPhysicalAssessmentsByFields(Dictionary<string, object> filters)
        {
            var entities = _physicalAssessmentRepository.FindPhysicalAssessmentsByFields(filters);
            return new ApplicationResponse<IEnumerable<PhysicalAssessment>>
            {
                Success = true,
                Data = entities
            };
        }
    }
}
