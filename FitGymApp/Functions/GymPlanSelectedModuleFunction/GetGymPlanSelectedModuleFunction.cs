using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.GymPlanSelectedModuleFunction
{
    public class GetGymPlanSelectedModuleFunction
    {
        private readonly ILogger<GetGymPlanSelectedModuleFunction> _logger;
        private readonly IGymPlanSelectedModuleService _service;

        public GetGymPlanSelectedModuleFunction(ILogger<GetGymPlanSelectedModuleFunction> logger, IGymPlanSelectedModuleService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GymPlanSelectedModule_GetGymPlanSelectedModuleByIdFunction")]
        public async Task<ApiResponse<GymPlanSelectedModule>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselectedmodule/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<GymPlanSelectedModule>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando GymPlanSelectedModule por Id: {id}");
            try
            {
                var result = await _service.GetGymPlanSelectedModuleByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<GymPlanSelectedModule>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<GymPlanSelectedModule>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar GymPlanSelectedModule por Id.");
                return new ApiResponse<GymPlanSelectedModule>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("GymPlanSelectedModule_GetAllGymPlanSelectedModulesFunction")]
        public async Task<ApiResponse<IEnumerable<GymPlanSelectedModule>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselectedmodules")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los GymPlanSelectedModules activos.");
            try
            {
                var result = await _service.GetAllGymPlanSelectedModulesAsync();
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los GymPlanSelectedModules.");
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("GymPlanSelectedModule_FindGymPlanSelectedModulesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<GymPlanSelectedModule>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselectedmodules/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando GymPlanSelectedModules por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindGymPlanSelectedModulesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar GymPlanSelectedModules por filtros.");
                return new ApiResponse<IEnumerable<GymPlanSelectedModule>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
