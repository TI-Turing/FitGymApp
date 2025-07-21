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

namespace FitGymApp.Functions.BrandFunction
{
    public class GetBrandFunction
    {
        private readonly ILogger<GetBrandFunction> _logger;
        private readonly IBrandService _brandService;

        public GetBrandFunction(ILogger<GetBrandFunction> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }

        [Function("Brand_GetBrandByIdFunction")]
        public async Task<ApiResponse<Brand>> GetBrandByIdAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "brand/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<Brand>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation($"Consultando marca por Id: {id}");
            try
            {
                var result = await _brandService.GetBrandByIdAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<Brand>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<Brand>
                {
                    Success = true,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar marca por Id.");
                return new ApiResponse<Brand>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Brand_GetAllBrandsFunction")]
        public async Task<ApiResponse<IEnumerable<Brand>>> GetAllBrandsAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "brands")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Brand>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando todas las marcas activas.");
            try
            {
                var result = await _brandService.GetAllBrandsAsync();
                return new ApiResponse<IEnumerable<Brand>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar todas las marcas.");
                return new ApiResponse<IEnumerable<Brand>>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = null,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        [Function("Brand_FindBrandsByFieldsFunction")]
        public async Task<ApiResponse<IEnumerable<Brand>>> FindBrandsByFieldsAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "brands/find")] HttpRequest req)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<IEnumerable<Brand>>
                {
                    Success = false,
                    Message = error!,
                    Data = null,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            _logger.LogInformation("Consultando marcas por filtros dinámicos.");
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var filters = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(requestBody);
                if (filters == null || filters.Count == 0)
                {
                    return new ApiResponse<IEnumerable<Brand>>
                    {
                        Success = false,
                        Message = "No se proporcionaron filtros válidos.",
                        Data = null,
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                var result = await _brandService.FindBrandsByFieldsAsync(filters);
                return new ApiResponse<IEnumerable<Brand>>
                {
                    Success = result.Success,
                    Message = result.Message,
                    Data = result.Data,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar marcas por filtros.");
                return new ApiResponse<IEnumerable<Brand>>
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
