using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using FitGymApp.Utils;

namespace FitGymApp.Functions.MachineCategoryFunction
{
    public class GetMachineCategoryFunction
    {
        private readonly ILogger<GetMachineCategoryFunction> _logger;
        private readonly IMachineCategoryService _service;

        public GetMachineCategoryFunction(ILogger<GetMachineCategoryFunction> logger, IMachineCategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("MachineCategory_GetMachineCategoryByIdFunction")]
        public async Task<ApiResponse<MachineCategory>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "machinecategory/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<MachineCategory>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando MachineCategory por Id: {id}");
            try
            {
                var result = await _service.GetMachineCategoryByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<MachineCategory>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<MachineCategory>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar MachineCategory por Id.");
                return new ApiResponse<MachineCategory>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("MachineCategory_GetAllMachineCategoriesFunction")]
        public async Task<ApiResponse<IEnumerable<MachineCategory>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "machinecategories")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<MachineCategory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los MachineCategories activos.");
            try
            {
                var result = await _service.GetAllMachineCategoriesAsync();
                return new ApiResponse<IEnumerable<MachineCategory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los MachineCategories.");
                return new ApiResponse<IEnumerable<MachineCategory>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("MachineCategory_FindMachineCategoriesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<MachineCategory>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "machinecategories/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<MachineCategory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando MachineCategories por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<MachineCategory>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindMachineCategoriesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<MachineCategory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar MachineCategories por filtros.");
                return new ApiResponse<IEnumerable<MachineCategory>>
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
