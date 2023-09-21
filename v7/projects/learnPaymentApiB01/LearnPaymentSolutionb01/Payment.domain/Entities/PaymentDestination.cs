using Payment.domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.domain.Entities
{
    public class PaymentDestination : BaseAuditableEntity
    {
        public string Id { get; set; } = string.Empty;
        public string? DestLogo { get; set; } = string.Empty;
        public string? DesShortName { get; set; } = string.Empty;
        public string? DesName { get; set; } = string.Empty;
        public int? DesSortIndex { get; set; }
        public string? ParentId { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
