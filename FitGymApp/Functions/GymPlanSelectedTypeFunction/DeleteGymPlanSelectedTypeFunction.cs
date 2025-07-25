using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using System;
using System.Threading.Tasks;
using Gymmetry.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Gymmetry.Functions.GymPlanSelectedTypeFunction
{
    public class DeleteGymPlanSelectedTypeFunction
    {
        private readonly ILogger<DeleteGymPlanSelectedTypeFunction> _logger;
        private readonly IGymPlanSelectedTypeService _service;

        public DeleteGymPlanSelectedTypeFunction(ILogger<DeleteGymPlanSelectedTypeFunction> logger, IGymPlanSelectedTypeService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("GymPlanSelectedType_DeleteGymPlanSelectedTypeFunction")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "gymplanselectedtype/{id:guid}")] HttpRequest req, Guid id)
        {
            if (!JwtValidator.ValidateJwt(req, out var error, out var userId))
            {
                return new JsonResult(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = error!,
                    Data = default,
                    StatusCode = StatusCodes.Status401Unauthorized
                });
            }

            _logger.LogInformation($"Procesando solicitud de borrado para GymPlanSelectedType {id}");
            try
            {
                var result = await _service.DeleteGymPlanSelectedTypeAsync(id);
                if (!result.Success)
                {
                    return new JsonResult(new ApiResponse<Guid>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = default,
                        StatusCode = StatusCodes.Status404NotFound
                    });
                }
                return new JsonResult(new ApiResponse<Guid>
                {
                    Success = true,
                    Message = result.Message,
                    Data = id,
                    StatusCode = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar GymPlanSelectedType.");
                return new JsonResult(new ApiResponse<Guid>
                {
                    Success = false,
                    Message = "Ocurrió un error al procesar la solicitud.",
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
