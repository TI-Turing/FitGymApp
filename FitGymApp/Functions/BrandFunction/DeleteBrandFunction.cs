using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FitGymApp.Application.Services.Interfaces;
using FitGymApp.Domain.DTO;
using FitGymApp.Domain.Models;
using System;
using System.Threading.Tasks;
using FitGymApp.Utils;

namespace FitGymApp.Functions.BrandFunction
{
    public class DeleteBrandFunction
    {
        private readonly ILogger<DeleteBrandFunction> _logger;
        private readonly IBrandService _brandService;

        public DeleteBrandFunction(ILogger<DeleteBrandFunction> logger, IBrandService brandService)
        {
            _logger = logger;
            _brandService = brandService;
        }

        [Function("Brand_DeleteBrandFunction")]
        public async Task<ApiResponse<Guid>> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "brand/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = error!,
                    Data = default,
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

            _logger.LogInformation($"Procesando solicitud de borrado para marca {id}");
            try
            {
                var result = await _brandService.DeleteBrandAsync(id);
                if (!result.Success)
                {
                    return new ApiResponse<Guid>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = default,
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
                return new ApiResponse<Guid>
                {
                    Success = true,
                    Message = result.Message,
                    Data = id,
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar marca.");
                return new ApiResponse<Guid>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
