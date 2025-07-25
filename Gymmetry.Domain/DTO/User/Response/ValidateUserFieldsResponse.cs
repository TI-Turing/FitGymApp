namespace Gymmetry.Domain.DTO.User.Response
{
    public class ValidateUserFieldsResponse
    {
        public bool IsComplete { get; set; }
        public List<string> MissingFields { get; set; } = new List<string>();
    }
}