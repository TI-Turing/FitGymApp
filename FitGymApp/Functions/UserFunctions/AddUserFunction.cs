using Gymmetry.Application.Services;
using Gymmetry.Application.Services.Interfaces;
using Gymmetry.Domain.DTO;
using Gymmetry.Domain.DTO.User.Request;
using Gymmetry.Domain.DTO.User.Response;
using Gymmetry.Domain.Models;
using Gymmetry.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gymmetry.Functions.UserFunctions;

public class AddUserFunction
{
    private readonly ILogger<AddUserFunction> _logger;
    private readonly IUserService _userService;

    public AddUserFunction(ILogger<AddUserFunction> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Function("User_AddUserFunction")]
    public async Task<HttpResponseData> AddAsync(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/add")] HttpRequestData req,
    FunctionContext executionContext)
    {
        var logger = executionContext.GetLogger("User_AddUserFunction");
        logger.LogInformation("C# HTTP trigger function processed a request.");

        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var objRequest = JsonConvert.DeserializeObject<AddRequest>(requestBody);

            var validationResult = ModelValidator.ValidateModel<AddRequest, AddResponse>(objRequest, StatusCodes.Status400BadRequest);
            if (validationResult is not null)
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteAsJsonAsync(validationResult);
                return badResponse;
            }

            var result = await _userService.CreateUserAsync(objRequest);

            if (!result.Success)
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteAsJsonAsync(new ApiResponse<AddResponse>
                {
                    Success = false,
                    Message = result.Message,
                    Data = default,
                    StatusCode = StatusCodes.Status400BadRequest
                });
                return errorResponse;
            }

            var token = await JwtTokenGenerator.GenerateTokenAsync(result.Data.Id, string.Empty, result.Data.Email);
            AddResponse addResponse = new AddResponse
            {
                Id = result.Data.Id,
                Token = token
            };

            var successResponse = req.CreateResponse(HttpStatusCode.Created);
            await successResponse.WriteAsJsonAsync(new ApiResponse<AddResponse>
            {
                Success = true,
                Message = result.Message,
                Data = addResponse,
                StatusCode = StatusCodes.Status200OK
            });
            return successResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing the request.");

            var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await errorResponse.WriteAsJsonAsync(new ApiResponse<AddResponse>
            {
                Success = false,
                Message = "Ocurrió un error al procesar la solicitud.",
                Data = default,
                StatusCode = StatusCodes.Status400BadRequest
            });
            return errorResponse;
        }
    }

}