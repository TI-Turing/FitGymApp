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

namespace Gymmetry.Functions.FitUserFunction
{
    public class GetFitUserFunction
    {
        private readonly ILogger<GetFitUserFunction> _logger;
        private readonly IFitUserService _service;

        public GetFitUserFunction(ILogger<GetFitUserFunction> logger, IFitUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("FitUser_GetFitUserByIdFunction")]
        public async Task<ApiResponse<FitUser>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "fituser/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<FitUser>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando FitUser por Id: {id}");
            try
            {
                var result = await _service.GetFitUserByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<FitUser>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<FitUser>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar FitUser por Id.");
                return new ApiResponse<FitUser>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("FitUser_GetAllFitUsersFunction")]
        public async Task<ApiResponse<IEnumerable<FitUser>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "fitusers")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<FitUser>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los FitUsers activos.");
            try
            {
                var result = await _service.GetAllFitUsersAsync();
                return new ApiResponse<IEnumerable<FitUser>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los FitUsers.");
                return new ApiResponse<IEnumerable<FitUser>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("FitUser_FindFitUsersByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<FitUser>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "fitusers/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<FitUser>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando FitUsers por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<FitUser>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindFitUsersByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<FitUser>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar FitUsers por filtros.");
                return new ApiResponse<IEnumerable<FitUser>>
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
