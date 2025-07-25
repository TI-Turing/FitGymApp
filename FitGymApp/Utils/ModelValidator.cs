using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Gymmetry.Domain.DTO;

namespace Gymmetry.Utils
{
    public static class ModelValidator
    {
        public static ApiResponse<TResponse>? ValidateModel<TRequest, TResponse>(TRequest objRequest, int statusCode = 400)
        {
            if (objRequest == null)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Message = "El cuerpo de la solicitud no coincide con la estructura esperada.",
                    Data = default,
                    StatusCode = statusCode
                };
            }

            var validationContext = new ValidationContext(objRequest, null, null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(objRequest, validationContext, validationResults, true);

            if (!isValid)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Message = string.Join("; ", validationResults.Select(v => v.ErrorMessage)),
                    Data = default,
                    StatusCode = statusCode
                };
            }
            return null;
        }
    }
}
