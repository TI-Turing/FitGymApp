namespace FitGymApp.Domain.DTO
{
    public class ApplicationResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public string? ErrorCode { get; set; }

        public static ApplicationResponse<T> SuccessResponse(T data, string message = "") => new()
        {
            Success = true,
            Data = data,
            Message = message
        };

        public static ApplicationResponse<T> ErrorResponse(string message, string? errorCode = null) => new()
        {
            Success = false,
            Message = message,
            ErrorCode = errorCode
        };
    }
}
