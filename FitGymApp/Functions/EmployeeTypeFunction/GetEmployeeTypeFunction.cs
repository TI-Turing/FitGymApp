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

namespace FitGymApp.Functions.EmployeeTypeFunction
{
    public class GetEmployeeTypeFunction
    {
        private readonly ILogger<GetEmployeeTypeFunction> _logger;
        private readonly IEmployeeTypeService _service;

        public GetEmployeeTypeFunction(ILogger<GetEmployeeTypeFunction> logger, IEmployeeTypeService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("EmployeeType_GetEmployeeTypeByIdFunction")]
        public async Task<ApiResponse<EmployeeType>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "employeetype/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<EmployeeType>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando EmployeeType por Id: {id}");
            try
            {
                var result = await _service.GetEmployeeTypeByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<EmployeeType>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<EmployeeType>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar EmployeeType por Id.");
                return new ApiResponse<EmployeeType>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("EmployeeType_GetAllEmployeeTypesFunction")]
        public async Task<ApiResponse<IEnumerable<EmployeeType>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "employeetypes")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<EmployeeType>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los EmployeeTypes activos.");
            try
            {
                var result = await _service.GetAllEmployeeTypesAsync();
                return new ApiResponse<IEnumerable<EmployeeType>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los EmployeeTypes.");
                return new ApiResponse<IEnumerable<EmployeeType>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("EmployeeType_FindEmployeeTypesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<EmployeeType>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "employeetypes/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<EmployeeType>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando EmployeeTypes por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<EmployeeType>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindEmployeeTypesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<EmployeeType>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar EmployeeTypes por filtros.");
                return new ApiResponse<IEnumerable<EmployeeType>>
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
