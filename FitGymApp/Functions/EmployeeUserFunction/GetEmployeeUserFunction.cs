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

namespace FitGymApp.Functions.EmployeeUserFunction
{
    public class GetEmployeeUserFunction
    {
        private readonly ILogger<GetEmployeeUserFunction> _logger;
        private readonly IEmployeeUserService _service;

        public GetEmployeeUserFunction(ILogger<GetEmployeeUserFunction> logger, IEmployeeUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("EmployeeUser_GetEmployeeUserByIdFunction")]
        public async Task<ApiResponse<EmployeeUser>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "employeeuser/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<EmployeeUser>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando EmployeeUser por Id: {id}");
            try
            {
                var result = await _service.GetEmployeeUserByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<EmployeeUser>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<EmployeeUser>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar EmployeeUser por Id.");
                return new ApiResponse<EmployeeUser>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("EmployeeUser_GetAllEmployeeUsersFunction")]
        public async Task<ApiResponse<IEnumerable<EmployeeUser>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "employeeusers")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<EmployeeUser>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los EmployeeUsers activos.");
            try
            {
                var result = await _service.GetAllEmployeeUsersAsync();
                return new ApiResponse<IEnumerable<EmployeeUser>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los EmployeeUsers.");
                return new ApiResponse<IEnumerable<EmployeeUser>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("EmployeeUser_FindEmployeeUsersByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<EmployeeUser>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "employeeusers/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<EmployeeUser>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando EmployeeUsers por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<EmployeeUser>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindEmployeeUsersByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<EmployeeUser>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar EmployeeUsers por filtros.");
                return new ApiResponse<IEnumerable<EmployeeUser>>
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
