using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FitGymApp.Utils;
using System.Text.Json;
using System.IO;

namespace FitGymApp.Functions.BillFunction
{
    public class GetBillFunction
    {
        private readonly ILogger<GetBillFunction> _logger;
        private readonly IBillService _service;

        public GetBillFunction(ILogger<GetBillFunction> logger, IBillService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("Bill_GetBillByIdFunction")]
        public async Task<ApiResponse<Bill>> GetByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "bill/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<Bill>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando Bill por Id: {id}");
            try
            {
                var result = await _service.GetBillByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<Bill>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<Bill>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Bill por Id.");
                return new ApiResponse<Bill>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Bill_GetAllBillsFunction")]
        public async Task<ApiResponse<IEnumerable<Bill>>> GetAllAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "bills")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Bill>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todos los Bills activos.");
            try
            {
                var result = await _service.GetAllBillsAsync();
                return new ApiResponse<IEnumerable<Bill>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todos los Bills.");
                return new ApiResponse<IEnumerable<Bill>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Bill_FindBillsByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<Bill>>> FindByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "bills/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Bill>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando Bills por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<Bill>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _service.FindBillsByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<Bill>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar Bills por filtros.");
                return new ApiResponse<IEnumerable<Bill>>
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
