using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class SchoolRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string SchoolName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string SchoolTypeId { get; set; }
    }

    public class SchoolTypeRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string SchoolTypeName { get; set; }
    }
}
