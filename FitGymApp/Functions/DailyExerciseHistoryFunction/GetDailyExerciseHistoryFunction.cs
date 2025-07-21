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

namespace FitGymApp.Functions.DailyExerciseHistoryFunction
{
    public class GetDailyExerciseHistoryFunction
    {
        private readonly ILogger<GetDailyExerciseHistoryFunction> _logger;
        private readonly IDailyExerciseHistoryService _service;

        public GetDailyExerciseHistoryFunction(ILogger<GetDailyExerciseHistoryFunction> logger, IDailyExerciseHistoryService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("DailyExerciseHistory_GetDailyExerciseHistoryByIdFunction")]
        public async Task<ApiResponse<DailyExerciseHistory>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyexercisehistory/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<DailyExerciseHistory>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando DailyExerciseHistory por Id: {id}");
            try
            {
                var result = await _service.GetDailyExerciseHistoryByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<DailyExerciseHistory>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<DailyExerciseHistory>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyExerciseHistory por Id.");
                return new ApiResponse<DailyExerciseHistory>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyExerciseHistory_GetAllDailyExerciseHistoriesFunction")]
        public async Task<ApiResponse<IEnumerable<DailyExerciseHistory>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyexercisehistories")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los DailyExerciseHistories activos.");
            try
            {
                var result = await _service.GetAllDailyExerciseHistoriesAsync();
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los DailyExerciseHistories.");
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyExerciseHistory_FindDailyExerciseHistoriesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<DailyExerciseHistory>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "dailyexercisehistories/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando DailyExerciseHistories por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindDailyExerciseHistoriesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyExerciseHistories por filtros.");
                return new ApiResponse<IEnumerable<DailyExerciseHistory>>
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
