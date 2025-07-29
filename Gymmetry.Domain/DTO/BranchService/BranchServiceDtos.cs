using System;

namespace Gymmetry.Domain.DTO.BranchService.Request
{
    public class AddBranchServiceRequest
    {
        public Guid BranchId { get; set; }
        public Guid BranchServiceTypeId { get; set; }
        public string? Notes { get; set; }
        public string? Ip { get; set; }
    }

    public class UpdateBranchServiceRequest
    {
        public Guid Id { get; set; }
        public Guid BranchId { get; set; }
        public Guid BranchServiceTypeId { get; set; }
        public string? Notes { get; set; }
        public string? Ip { get; set; }
        public bool IsActive { get; set; }
    }
}

namespace Gymmetry.Domain.DTO.BranchService.Response
{
    public class BranchServiceResponse
    {
        public Guid Id { get; set; }
        public Guid BranchId { get; set; }
        public Guid BranchServiceTypeId { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
