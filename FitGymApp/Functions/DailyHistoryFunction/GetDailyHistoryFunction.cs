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
using System.Linq;
using Gymmetry.Utils;

namespace Gymmetry.Functions.DailyHistoryFunction
{
    public class GetDailyHistoryFunction
    {
        private readonly ILogger<GetDailyHistoryFunction> _logger;
        private readonly IDailyHistoryService _service;

        public GetDailyHistoryFunction(ILogger<GetDailyHistoryFunction> logger, IDailyHistoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("DailyHistory_GetDailyHistoryByIdFunction")]
        public async Task<ApiResponse<DailyHistory>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyhistory/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<DailyHistory>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando DailyHistory por Id: {id}");
            try
            {
                var result = await _service.GetDailyHistoryByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<DailyHistory>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<DailyHistory>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyHistory por Id.");
                return new ApiResponse<DailyHistory>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyHistory_GetAllDailyHistoriesFunction")]
        public async Task<ApiResponse<IEnumerable<DailyHistory>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyhistories")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyHistory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los DailyHistories activos.");
            try
            {
                var result = await _service.GetAllDailyHistoriesAsync();
                return new ApiResponse<IEnumerable<DailyHistory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los DailyHistories.");
                return new ApiResponse<IEnumerable<DailyHistory>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyHistory_FindDailyHistoriesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<DailyHistory>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "dailyhistories/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyHistory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando DailyHistories por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<DailyHistory>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindDailyHistoriesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<DailyHistory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyHistories por filtros.");
                return new ApiResponse<IEnumerable<DailyHistory>>
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
