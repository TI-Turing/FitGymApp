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

namespace FitGymApp.Functions.GymPlanSelectedTypeFunction
{
    public class GetGymPlanSelectedTypeFunction
    {
        private readonly ILogger<GetGymPlanSelectedTypeFunction> _logger;
        private readonly IGymPlanSelectedTypeService _service;

        public GetGymPlanSelectedTypeFunction(ILogger<GetGymPlanSelectedTypeFunction> logger, IGymPlanSelectedTypeService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GetGymPlanSelectedTypeByIdFunction")]
        public async Task<ApiResponse<GymPlanSelectedType>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselectedtype/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error))
            {
                return new ApiResponse<GymPlanSelectedType>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando GymPlanSelectedType por Id: {id}");
            try
            {
                var result = _service.GetGymPlanSelectedTypeById(id);
                if (!result.Success)
                {
                    return new ApiResponse<GymPlanSelectedType>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<GymPlanSelectedType>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar GymPlanSelectedType por Id.");
                return new ApiResponse<GymPlanSelectedType>
                {
                    Success = false,
                    Message = "Ocurri� un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("GetAllGymPlanSelectedTypesFunction")]
        public async Task<ApiResponse<IEnumerable<GymPlanSelectedType>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "gymplanselectedtypes")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error))
            {
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los GymPlanSelectedTypes activos.");
            try
            {
                var result = _service.GetAllGymPlanSelectedTypes();
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los GymPlanSelectedTypes.");
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = false,
                    Message = "Ocurri� un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("FindGymPlanSelectedTypesByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<GymPlanSelectedType>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "gymplanselectedtypes/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error))
            {
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando GymPlanSelectedTypes por filtros din�micos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros v�lidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = _service.FindGymPlanSelectedTypesByFields(filters);
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar GymPlanSelectedTypes por filtros.");
                return new ApiResponse<IEnumerable<GymPlanSelectedType>>
                {
                    Success = false,
                    Message = "Ocurri� un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
