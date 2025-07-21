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

namespace FitGymApp.Functions.DailyExerciseFunction
{
    public class GetDailyExerciseFunction
    {
        private readonly ILogger<GetDailyExerciseFunction> _logger;
        private readonly IDailyExerciseService _service;

        public GetDailyExerciseFunction(ILogger<GetDailyExerciseFunction> logger, IDailyExerciseService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("DailyExercise_GetDailyExerciseByIdFunction")]
        public async Task<ApiResponse<DailyExercise>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyexercise/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<DailyExercise>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando DailyExercise por Id: {id}");
            try
            {
                var result = await _service.GetDailyExerciseByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<DailyExercise>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<DailyExercise>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyExercise por Id.");
                return new ApiResponse<DailyExercise>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyExercise_GetAllDailyExercisesFunction")]
        public async Task<ApiResponse<IEnumerable<DailyExercise>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "dailyexercises")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyExercise>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los DailyExercises activos.");
            try
            {
                var result = await _service.GetAllDailyExercisesAsync();
                return new ApiResponse<IEnumerable<DailyExercise>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los DailyExercises.");
                return new ApiResponse<IEnumerable<DailyExercise>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("DailyExercise_FindDailyExercisesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<DailyExercise>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "dailyexercises/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<DailyExercise>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando DailyExercises por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<DailyExercise>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindDailyExercisesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<DailyExercise>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar DailyExercises por filtros.");
                return new ApiResponse<IEnumerable<DailyExercise>>
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
