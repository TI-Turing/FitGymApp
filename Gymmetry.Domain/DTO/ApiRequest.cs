using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymmetry.Domain.DTO
{
    public class ApiRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Search { get; set; }
        public string Fields { get; set; }
        public string OrderBy { get; set; }
        public string? Ip { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
