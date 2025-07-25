using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.Models;
using System;
using System.Threading.Tasks;
using Gymmetry.Utils;

namespace Gymmetry.Functions.EmployeeRegisterDailyFunction
{
    public class DeleteEmployeeRegisterDailyFunction
    {
        private readonly ILogger<DeleteEmployeeRegisterDailyFunction> _logger;
        private readonly IEmployeeRegisterDailyService _service;

        public DeleteEmployeeRegisterDailyFunction(ILogger<DeleteEmployeeRegisterDailyFunction> logger, IEmployeeRegisterDailyService service)
        {
            _logger = logger;
            _service = service;
        }

        [Function("EmployeeRegisterDaily_DeleteEmployeeRegisterDailyFunction")]
        public async Task<ApiResponse<Guid>> RunAsync([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "employeeregisterdaily/{id:guid}")] HttpRequest req, Guid id)
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

            _logger.LogInformation($"Procesando solicitud de borrado para EmployeeRegisterDaily {id}");
            try
            {
                var result = await _service.DeleteEmployeeRegisterDailyAsync(id);
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
                _logger.LogError(ex, "Error al eliminar EmployeeRegisterDaily.");
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
