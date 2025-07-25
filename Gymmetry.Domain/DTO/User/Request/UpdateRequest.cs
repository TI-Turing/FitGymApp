using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO.User.Request
{
    public class UpdateRequest : ApiRequest
    {
        public Guid Id { get; set; }
        public Guid? IdEps { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public Guid? IdGender { get; set; }
        public DateTime? BirthDate { get; set; } = null;
        public Guid? DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }
        public string? Phone { get; set; }
        public Guid? CountryId { get; set; }
        public string? Address { get; set; }
        public Guid? CityId { get; set; }
        public Guid? RegionId { get; set; }
        public string? Rh { get; set; }
        public string? EmergencyName { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? PhysicalExceptions { get; set; }
        public Guid? UserTypeId { get; set; } = null;
        // No incluir Password aquí, nunca debe actualizarse por este método
    }
}
