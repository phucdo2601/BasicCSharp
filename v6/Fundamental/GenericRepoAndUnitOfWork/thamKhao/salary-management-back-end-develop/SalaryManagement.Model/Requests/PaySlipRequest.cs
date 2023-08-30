using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class PaySlipRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string PayPeriodId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
    }

    public class PaySlipDetailRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string PaySlipId { get; set; }

        [Required]
        public List<PaySlipItemRequest> Attributes { get; set; }
    }

    public class PaySlipItemRequest
    {
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Attribute { get; set; }

        [Required]
        public double Value { get; set; }
    }

    public class PaySlipCheckRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        public List<PaySlipItemRequest> Attributes { get; set; }
    }

    public class PaySlip1YearRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        public int Year { get; set; }
    }

    public class TeachingSummaryRequest
    {
        public int AttendedTeaching { get; set; }

        public int PlanTeaching { get; set; }

        public double Average { get; set; }

        public int TotalDay { get; set; }

        public double TotalWeek { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string PaySlipId { get; set; }

        [Required]
        public List<TeachingSummaryDetailRequest> TeachingSummaryDetails { get; set; }
    }

    public class TeachingSummaryDetailRequest
    {
        public DateTime Date { get; set; }

        public int Slot { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Room { get; set; }

        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Course { get; set; }

        public int? SessionNo { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Student { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Attendance { get; set; }
    }

    public class PaySlipByMonthRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
    }

    public class PaySlipCheckTax
    {
        [Required]
        public List<PaySlipItemRequest> Attributes { get; set; }
    }

    public class ItemValue
    {
        public double Value { get; set; }

        public double Quantity { get; set; }
    }
}
