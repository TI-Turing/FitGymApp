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

namespace FitGymApp.Functions.LogUninstallFunction
{
    public class GetLogUninstallFunction
    {
        private readonly ILogger<GetLogUninstallFunction> _logger;
        private readonly ILogUninstallService _service;

        public GetLogUninstallFunction(ILogger<GetLogUninstallFunction> logger, ILogUninstallService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("LogUninstall_GetLogUninstallByIdFunction")]
        public async Task<ApiResponse<LogUninstall>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "loguninstall/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<LogUninstall>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando LogUninstall por Id: {id}");
            try
            {
                var result = await _service.GetLogUninstallByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<LogUninstall>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<LogUninstall>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar LogUninstall por Id.");
                return new ApiResponse<LogUninstall>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("LogUninstall_GetAllLogUninstallsFunction")]
        public async Task<ApiResponse<IEnumerable<LogUninstall>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "loguninstalls")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<LogUninstall>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los LogUninstall activos.");
            try
            {
                var result = await _service.GetAllLogUninstallsAsync();
                return new ApiResponse<IEnumerable<LogUninstall>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los LogUninstall.");
                return new ApiResponse<IEnumerable<LogUninstall>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("LogUninstall_FindLogUninstallsByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<LogUninstall>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "loguninstalls/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<LogUninstall>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando LogUninstalls por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<LogUninstall>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindLogUninstallsByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<LogUninstall>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar LogUninstalls por filtros.");
                return new ApiResponse<IEnumerable<LogUninstall>>
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
