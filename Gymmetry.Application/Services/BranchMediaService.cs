using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.Models;
using Gymmetry.Domain.DTO;
using Gymmetry.Repository.Services.Interfaces;

namespace Gymmetry.Application.Services
{
    public class BranchMediaService : IBranchMediaService
    {
        private readonly IBranchMediaRepository _repo;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        public BranchMediaService(IBranchMediaRepository repo, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _repo = repo;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }
        public async Task<ApplicationResponse<BranchMedia>> CreateBranchMediaAsync(BranchMedia entity)
        {
            try
            {
                var created = await _repo.CreateBranchMediaAsync(entity);
                return ApplicationResponse<BranchMedia>.SuccessResponse(created, "BranchMedia creado correctamente.");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<BranchMedia>.ErrorResponse("Error técnico al crear BranchMedia.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<BranchMedia>> GetBranchMediaByIdAsync(Guid id)
        {
            var entity = await _repo.GetBranchMediaByIdAsync(id);
            if (entity == null)
                return ApplicationResponse<BranchMedia>.ErrorResponse("BranchMedia no encontrado.", "NotFound");
            return ApplicationResponse<BranchMedia>.SuccessResponse(entity);
        }
        public async Task<ApplicationResponse<IEnumerable<BranchMedia>>> GetAllBranchMediasAsync()
        {
            var entities = await _repo.GetAllBranchMediasAsync();
            return ApplicationResponse<IEnumerable<BranchMedia>>.SuccessResponse(entities);
        }
        public async Task<ApplicationResponse<bool>> UpdateBranchMediaAsync(BranchMedia entity)
        {
            try
            {
                var before = await _repo.GetBranchMediaByIdAsync(entity.Id);
                var updated = await _repo.UpdateBranchMediaAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("BranchMedia", before, entity.Id);
                    return ApplicationResponse<bool>.SuccessResponse(true, "BranchMedia actualizado correctamente.");
                }
                return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar BranchMedia.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar BranchMedia.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<bool>> DeleteBranchMediaAsync(Guid id)
        {
            try
            {
                var deleted = await _repo.DeleteBranchMediaAsync(id);
                if (deleted)
                    return ApplicationResponse<bool>.SuccessResponse(true, "BranchMedia eliminado correctamente.");
                return ApplicationResponse<bool>.ErrorResponse("BranchMedia no encontrado o ya eliminado.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar BranchMedia.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<IEnumerable<BranchMedia>>> FindBranchMediasByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _repo.FindBranchMediasByFieldsAsync(filters);
            return ApplicationResponse<IEnumerable<BranchMedia>>.SuccessResponse(entities);
        }
    }

    public class CurrentOccupancyService : ICurrentOccupancyService
    {
        private readonly ICurrentOccupancyRepository _repo;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        public CurrentOccupancyService(ICurrentOccupancyRepository repo, ILogChangeService logChangeService, ILogErrorService logErrorService)
        {
            _repo = repo;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
        }
        public async Task<ApplicationResponse<CurrentOccupancy>> CreateCurrentOccupancyAsync(CurrentOccupancy entity)
        {
            try
            {
                var created = await _repo.CreateCurrentOccupancyAsync(entity);
                return ApplicationResponse<CurrentOccupancy>.SuccessResponse(created, "CurrentOccupancy creado correctamente.");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<CurrentOccupancy>.ErrorResponse("Error técnico al crear CurrentOccupancy.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<CurrentOccupancy>> GetCurrentOccupancyByIdAsync(Guid id)
        {
            var entity = await _repo.GetCurrentOccupancyByIdAsync(id);
            if (entity == null)
                return ApplicationResponse<CurrentOccupancy>.ErrorResponse("CurrentOccupancy no encontrado.", "NotFound");
            return ApplicationResponse<CurrentOccupancy>.SuccessResponse(entity);
        }
        public async Task<ApplicationResponse<IEnumerable<CurrentOccupancy>>> GetAllCurrentOccupanciesAsync()
        {
            var entities = await _repo.GetAllCurrentOccupanciesAsync();
            return ApplicationResponse<IEnumerable<CurrentOccupancy>>.SuccessResponse(entities);
        }
        public async Task<ApplicationResponse<bool>> UpdateCurrentOccupancyAsync(CurrentOccupancy entity)
        {
            try
            {
                var before = await _repo.GetCurrentOccupancyByIdAsync(entity.Id);
                var updated = await _repo.UpdateCurrentOccupancyAsync(entity);
                if (updated)
                {
                    await _logChangeService.LogChangeAsync("CurrentOccupancy", before, entity.Id);
                    return ApplicationResponse<bool>.SuccessResponse(true, "CurrentOccupancy actualizado correctamente.");
                }
                return ApplicationResponse<bool>.ErrorResponse("No se pudo actualizar CurrentOccupancy.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al actualizar CurrentOccupancy.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<bool>> DeleteCurrentOccupancyAsync(Guid id)
        {
            try
            {
                var deleted = await _repo.DeleteCurrentOccupancyAsync(id);
                if (deleted)
                    return ApplicationResponse<bool>.SuccessResponse(true, "CurrentOccupancy eliminado correctamente.");
                return ApplicationResponse<bool>.ErrorResponse("CurrentOccupancy no encontrado o ya eliminado.", "NotFound");
            }
            catch (Exception ex)
            {
                await _logErrorService.LogErrorAsync(ex);
                return ApplicationResponse<bool>.ErrorResponse("Error técnico al eliminar CurrentOccupancy.", "TechnicalError");
            }
        }
        public async Task<ApplicationResponse<IEnumerable<CurrentOccupancy>>> FindCurrentOccupanciesByFieldsAsync(Dictionary<string, object> filters)
        {
            var entities = await _repo.FindCurrentOccupanciesByFieldsAsync(filters);
            return ApplicationResponse<IEnumerable<CurrentOccupancy>>.SuccessResponse(entities);
        }
    }
}
