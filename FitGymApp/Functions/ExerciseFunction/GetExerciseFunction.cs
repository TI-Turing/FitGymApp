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

namespace Gymmetry.Functions.ExerciseFunction
{
    public class GetExerciseFunction
    {
        private readonly ILogger<GetExerciseFunction> _logger;
        private readonly IExerciseService _service;

        public GetExerciseFunction(ILogger<GetExerciseFunction> logger, IExerciseService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Exercise_GetExerciseByIdFunction")]
        public async Task<ApiResponse<Exercise>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "exercise/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<Exercise>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando Exercise por Id: {id}");
            try
            {
                var result = await _service.GetExerciseByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<Exercise>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<Exercise>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Exercise por Id.");
                return new ApiResponse<Exercise>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Exercise_GetAllExercisesFunction")]
        public async Task<ApiResponse<IEnumerable<Exercise>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "exercises")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Exercise>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los Exercises activos.");
            try
            {
                var result = await _service.GetAllExercisesAsync();
                return new ApiResponse<IEnumerable<Exercise>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los Exercises.");
                return new ApiResponse<IEnumerable<Exercise>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Exercise_FindExercisesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<Exercise>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "exercises/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Exercise>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando Exercises por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<Exercise>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindExercisesByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<Exercise>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Exercises por filtros.");
                return new ApiResponse<IEnumerable<Exercise>>
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
