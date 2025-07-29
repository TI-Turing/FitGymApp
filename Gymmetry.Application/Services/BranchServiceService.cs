using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO.BranchService.Request;
using Gymmetry.Domain.DTO.BranchService.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class BranchServiceService : IBranchServiceService
    {
        private readonly IBranchServiceRepository _repo;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        public BranchServiceService(IBranchServiceRepository repo, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _repo = repo;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }
        public async Task<ApplicationResponse<BranchServiceResponse>> CreateBranchServiceAsync(AddBranchServiceRequest request)
        {
            try
            {
                var entity = new Domain.Models.BranchService
                {
                    BranchId = request.BranchId,
                    BranchServiceTypeId = request.BranchServiceTypeId,
                    Notes = request.Notes,
                    Ip = request.Ip,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };
                var created = await _repo.CreateBranchServiceAsync(entity);
                var response = new BranchServiceResponse
                {
                    Id = created.Id,
                    BranchId = created.BranchId,
                    BranchServiceTypeId = created.BranchServiceTypeId,
                    Notes = created.Notes,
                    CreatedAt = created.CreatedAt,
                    UpdatedAt = created.UpdatedAt,
                    IsActive = created.IsActive
                };
                return ApplicationResponse<BranchServiceResponse>.SuccessResponse(response, "BranchService creado correctamente.");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<BranchServiceResponse>.ErrorResponse("Error técnico al crear BranchService.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<BranchServiceResponse>> GetBranchServiceByIdAsync(Guid id)
        {
            var entity = await _repo.GetBranchServiceByIdAsync(id);
            if (entity == null)
                return ApplicationResponse<BranchServiceResponse>.ErrorResponse("BranchService no encontrado.", "NotFound");
            var response = new BranchServiceResponse
            {
                Id = entity.Id,
                BranchId = entity.BranchId,
                BranchServiceTypeId = entity.BranchServiceTypeId,
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive
            };
            return ApplicationResponse<BranchServiceResponse>.SuccessResponse(response);
        }
        public async Task<ApplicationResponse<IEnumerable<BranchServiceResponse>>> GetAllBranchServicesAsync()
        {
            var entities = await _repo.GetAllBranchServicesAsync();
            var responses = entities.Select(entity => new BranchServiceResponse
            {
                Id = entity.Id,
                BranchId = entity.BranchId,
                BranchServiceTypeId = entity.BranchServiceTypeId,
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive
            });
            return ApplicationResponse<IEnumerable<BranchServiceResponse>>.SuccessResponse(responses);
        }
        public async Task<ApplicationResponse<bool>> UpdateBranchServiceAsync(UpdateBranchServiceRequest request)
        {
            try
            {
                var before = await _repo.GetBranchServiceByIdAsync(request.Id);
                if (before == null)
                    return ApplicationResponse<bool>.ErrorResponse("BranchService no encontrado.", "NotFound");
                var entity = new Domain.Models.BranchService
                {
                    Id = request.Id,
                    BranchId = request.BranchId,
                    BranchServiceTypeId = request.BranchServiceTypeId,
                    Notes = request.Notes,
                    Ip = request.Ip,
                    IsActive = request.IsActive,
                    CreatedAt = before.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                };
                var updated = await _repo.UpdateBranchServiceAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("BranchService", before, entity.Id);
                    return ApplicationResponse<bool>.SuccessResponse(true, "BranchService actualizado correctamente.");
                }
                return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar BranchService.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar BranchService.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<bool>> DeleteBranchServiceAsync(Guid id)
        {
            try
            {
                var deleted = await _repo.DeleteBranchServiceAsync(id);
                if (deleted)
                    return ApplicationResponse<bool>.SuccessResponse(true, "BranchService eliminado correctamente.");
                return ApplicationResponse<bool>.ErrorResponse("BranchService no encontrado o ya eliminado.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar BranchService.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<IEnumerable<BranchServiceResponse>>> FindBranchServicesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _repo.FindBranchServicesByFieldsAsync(filters);
            var responses = entities.Select(entity => new BranchServiceResponse
            {
                Id = entity.Id,
                BranchId = entity.BranchId,
                BranchServiceTypeId = entity.BranchServiceTypeId,
                Notes = entity.Notes,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                IsActive = entity.IsActive
            });
            return ApplicationResponse<IEnumerable<BranchServiceResponse>>.SuccessResponse(responses);
        }
    }
}
