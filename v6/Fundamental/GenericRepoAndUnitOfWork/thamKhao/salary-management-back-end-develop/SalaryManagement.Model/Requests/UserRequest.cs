using System;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class AdminRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The {0} must be between 8 to 20 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }

    public class AdminUpdateRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }

    public class UserPasswordRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PasswordOld { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The {0} must be between 8 to 20 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character")]
        public string PasswordNew { get; set; }
    }

    public class LecturerRequest
    {
        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "The {0} must be 8 digits.")]
        public string LecturerCode { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The {0} must be between 8 to 20 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string DepartmentId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerTypeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string BasicSalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FesalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerPositionId { get; set; }
    }

    public class LecturerUpdateRequest
    {
        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "The {0} must be 8 digits.")]
        public string LecturerCode { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string DepartmentId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerTypeId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string BasicSalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FesalaryId { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string LecturerPositionId { get; set; }
    }

    public class ManagerRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The {0} must be between 8 to 20 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string RoleId { get; set; }
    }

    public class ManagerUpdateRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }
    }

    public class UserRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,20}$", ErrorMessage = "The {0} must be between 8 to 20 characters and contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character")]
        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid {0}")]
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [RegularExpression(@"^\S*$", ErrorMessage = "The {0} must not contain spaces.")]
        public string Gmail { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string NationalId { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        [Url(ErrorMessage = "Invalid {0}")]
        public string ImageUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Address { get; set; }

        [Required]
        public bool IsDisable { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string RoleId { get; set; }
    }

    public class LecturerTypeRequest
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string LecturerTypeName { get; set; }

        [Required]
        [Range(2, 28, ErrorMessage = "StatisticsStartDay must be between 2 and 28")]
        public int StatisticsStartDay { get; set; }

        [Required]
        [Range(1, 27, ErrorMessage = "StatisticsEndDay must be between 1 and 27")]
        public int StatisticsEndDay { get; set; }

        [Required]
        [Range(1, 28, ErrorMessage = "PayDay must be between 1 and 28")]
        public int PayDay { get; set; }

        [Required]
        [RegularExpression(@"^([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$", ErrorMessage = "{0} must be Guid")]
        public string FormulaId { get; set; }
    }
}
