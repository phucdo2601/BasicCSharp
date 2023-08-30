using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class SemesterRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string SemesterName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
    }

    public class SemesterSchoolRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string SchoolTypeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string SemesterId { get; set; }
    }
}
