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

namespace FitGymApp.Functions.DailyFunction
{
    public class GetDailyFunction
    {
        private readonly ILogger<GetDailyFunction> _logger;
        private readonly IDailyService _service;

        public GetDailyFunction(ILogger<GetDailyFunction> logger, IDailyService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Daily_GetDailyByIdFunction")]
        public async Task<ApiResponse<Daily>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "daily/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<Daily>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando Daily por Id: {id}");
            try
            {
                var result = await _service.GetDailyByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<Daily>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<Daily>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Daily por Id.");
                return new ApiResponse<Daily>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Daily_GetAllDailiesFunction")]
        public async Task<ApiResponse<IEnumerable<Daily>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailies")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Daily>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los Dailies activos.");
            try
            {
                var result = await _service.GetAllDailiesAsync();
                return new ApiResponse<IEnumerable<Daily>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los Dailies.");
                return new ApiResponse<IEnumerable<Daily>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Daily_FindDailiesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<Daily>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "dailies/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Daily>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando Dailies por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<Daily>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindDailiesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<Daily>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Dailies por filtros.");
                return new ApiResponse<IEnumerable<Daily>>
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
