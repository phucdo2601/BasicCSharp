using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class BasicSalaryRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string BasicSalaryLevel { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Salary { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double TimeLearningLimit { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }
    public class FESalaryRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FesalaryCode { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Salary { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }
    public class BasicSalaryLecturer
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string BasicSalaryId { get; set; }
    }
    public class FESalaryLecturer
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FESalaryId { get; set; }
    }

    public partial class SalaryHistoryRequest
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }

        [Required]
        public double BasicSalary { get; set; }

        [Required]
        public double Fesalary { get; set; }

        [Required]
        public bool IsUsing { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string BasicSalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FesalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerTypeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }
    }
}
