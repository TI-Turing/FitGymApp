using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.Models;
using FitGymApp.Domain.DTO.Branch.Request;
using FitGymApp.Domain.DTO;
using FitGymApp.Repository.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace FitGymApp.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ILogChangeService _logChangeService;
        private readonly ILogErrorService _logErrorService;
        private readonly IMapper _mapper;
        private readonly ILogger<BranchService> _logger;

        public BranchService(IBranchRepository branchRepository, ILogChangeService logChangeService, ILogErrorService logErrorService, IMapper mapper, ILogger<BranchService> logger)
        {
            _branchRepository = branchRepository;
            _logChangeService = logChangeService;
            _logErrorService = logErrorService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApplicationResponse<Branch>> CreateBranchAsync(AddBranchRequest request)
        {
            _logger.LogInformation("Starting CreateBranchAsync method.");
            try
            {
                var branch = _mapper.Map<Branch>(request);
                var created = await _branchRepository.CreateBranchAsync(branch);
                _logger.LogInformation("Branch created successfully with ID: {BranchId}", created.Id);
                return new ApplicationResponse<Branch>
                {
                    Success = true,
                    Message = "Sucursal creada correctamente.",
                    Data = created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a branch.");
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Branch>
                {
                    Success = false,
                    Message = "Error técnico al crear la sucursal.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<Branch>> GetBranchByIdAsync(Guid id)
        {
            _logger.LogInformation("Starting GetBranchByIdAsync method for BranchId: {BranchId}", id);
            try
            {
                var branch = await _branchRepository.GetBranchByIdAsync(id);
                if (branch == null)
                {
                    _logger.LogWarning("Branch not found for BranchId: {BranchId}", id);
                    return new ApplicationResponse<Branch>
                    {
                        Success = false,
                        Message = "Sucursal no encontrada.",
                        ErrorCode = "NotFound"
                    };
                }
                _logger.LogInformation("Branch retrieved successfully for BranchId: {BranchId}", id);
                return new ApplicationResponse<Branch>
                {
                    Success = true,
                    Data = branch
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving branch with BranchId: {BranchId}", id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<Branch>
                {
                    Success = false,
                    Message = "Error técnico al obtener la sucursal.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Branch>>> GetAllBranchesAsync()
        {
            _logger.LogInformation("Starting GetAllBranchesAsync method.");
            try
            {
                var branches = await _branchRepository.GetAllBranchesAsync();
                _logger.LogInformation("Retrieved {BranchCount} branches successfully.", branches.Count());
                return new ApplicationResponse<IEnumerable<Branch>>
                {
                    Success = true,
                    Data = branches
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all branches.");
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<IEnumerable<Branch>>
                {
                    Success = false,
                    Message = "Error técnico al obtener las sucursales.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> UpdateBranchAsync(UpdateBranchRequest request, Guid? userId, string ip = "", string invocationId = "")
        {
            _logger.LogInformation("Starting UpdateBranchAsync method for BranchId: {BranchId}", request.Id);
            try
            {
                var branchBefore = await _branchRepository.GetBranchByIdAsync(request.Id);
                if (branchBefore == null)
                {
                    _logger.LogWarning("Branch not found for BranchId: {BranchId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Sucursal no encontrada.",
                        ErrorCode = "NotFound"
                    };
                }

                var branch = _mapper.Map<Branch>(request);
                var updated = await _branchRepository.UpdateBranchAsync(branch);
                if (updated)
                {
                    _logger.LogInformation("Branch updated successfully for BranchId: {BranchId}", request.Id);
                    await _logChangeService.LogChangeAsync("Branch", branchBefore, userId, ip, invocationId);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Sucursal actualizada correctamente."
                    };
                }
                else
                {
                    _logger.LogWarning("Could not update branch for BranchId: {BranchId}", request.Id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "No se pudo actualizar la sucursal.",
                        ErrorCode = "UpdateFailed"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating branch with BranchId: {BranchId}", request.Id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al actualizar la sucursal.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteBranchAsync(Guid id)
        {
            _logger.LogInformation("Starting DeleteBranchAsync method for BranchId: {BranchId}", id);
            try
            {
                var deleted = await _branchRepository.DeleteBranchAsync(id);
                if (deleted)
                {
                    _logger.LogInformation("Branch deleted successfully for BranchId: {BranchId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = true,
                        Data = true,
                        Message = "Sucursal eliminada correctamente."
                    };
                }
                else
                {
                    _logger.LogWarning("Branch not found or already deleted for BranchId: {BranchId}", id);
                    return new ApplicationResponse<bool>
                    {
                        Success = false,
                        Data = false,
                        Message = "Sucursal no encontrada o ya eliminada.",
                        ErrorCode = "NotFound"
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting branch with BranchId: {BranchId}", id);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error técnico al eliminar la sucursal.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<IEnumerable<Branch>>> FindBranchesByFieldsAsync(Dictionary<string, object> filters)
        {
            _logger.LogInformation("Starting FindBranchesByFieldsAsync method with filters: {Filters}", filters);
            try
            {
                var branches = await _branchRepository.FindBranchesByFieldsAsync(filters);
                _logger.LogInformation("Retrieved {BranchCount} branches successfully with filters.", branches.Count());
                return new ApplicationResponse<IEnumerable<Branch>>
                {
                    Success = true,
                    Data = branches
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while finding branches with filters: {Filters}", filters);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<IEnumerable<Branch>>
                {
                    Success = false,
                    Message = "Error técnico al buscar las sucursales.",
                    ErrorCode = "TechnicalError"
                };
            }
        }

        public async Task<ApplicationResponse<bool>> DeleteBranchesByGymIdAsync(Guid gymId)
        {
            _logger.LogInformation("Starting DeleteBranchesByGymIdAsync method for GymId: {GymId}", gymId);
            try
            {
                var filters = new Dictionary<string, object> { { "GymId", gymId } };
                var branches = await FindBranchesByFieldsAsync(filters);
                foreach (var branch in branches.Data)
                {
                    await _branchRepository.DeleteBranchAsync(branch.Id);
                }
                _logger.LogInformation("Deleted {BranchCount} branches successfully for GymId: {GymId}", branches.Data.Count(), gymId);
                return new ApplicationResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Branches deleted successfully."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting branches for GymId: {GymId}", gymId);
                await _logErrorService.LogErrorAsync(ex);
                return new ApplicationResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Error while deleting branches by GymId.",
                    ErrorCode = "TechnicalError"
                };
            }
        }
    }
}
