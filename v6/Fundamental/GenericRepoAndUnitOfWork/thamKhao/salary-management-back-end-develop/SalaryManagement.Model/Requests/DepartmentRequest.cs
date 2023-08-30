using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class DepartmentRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string DepartmentName { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string SchoolId { get; set; }
    }

    public class LecDepRequest
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        public bool IsWorking { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerPositionId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string DepartmentId { get; set; }
    }

    public class LecWorkingRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string DepartmentId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        public bool IsWorking { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerPositionId { get; set; }
    }

    public class PositionRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string LecturerPositionName { get; set; }
    }
}
