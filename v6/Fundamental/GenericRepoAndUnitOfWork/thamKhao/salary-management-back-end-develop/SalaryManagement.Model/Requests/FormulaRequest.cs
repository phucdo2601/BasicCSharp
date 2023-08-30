using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class PayPolicyRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PolicyName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PolicyNo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
    }

    public class GroupAttributeRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string GroupName { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }

    public class FormulaAttributeRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The {0} must not contain spaces and special characters.")]
        public string Attribute { get; set; }

        public double? Value { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string AttributeName { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        public double? Limit { get; set; }

        public List<string> DepartmentIds { get; set; }

        public string FormulaAttributeTypeId { get; set; }

        [Required]
        public string GroupAttributeId { get; set; }
    }

    public class FormulaRequest
    {
        [Required]
        [StringLength(4000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string CalculationFormula { get; set; }

        public List<string> FormulaAttributes { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FormulaName { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string PayPolicyId { get; set; }
    }

    public class FormulaNotAttrRequest
    {
        [Required]
        [StringLength(4000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string CalculationFormula { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FormulaName { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string PayPolicyId { get; set; }
    }

    public class FormulaCheckRequest
    {
        [Required]
        [StringLength(4000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string CalculationFormula { get; set; }

        public List<string> FormulaAttributes { get; set; }
    }

    public class FormulaCheckNotAttrRequest
    {
        [Required]
        [StringLength(4000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string CalculationFormula { get; set; }
    }

    public class FormulaAttrGroupRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FormulaAttributeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string GroupAttributeId { get; set; }
    }

    public class FormulaLecTypeRequest
    {
        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerTypeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FormulaId { get; set; }
    }
}
