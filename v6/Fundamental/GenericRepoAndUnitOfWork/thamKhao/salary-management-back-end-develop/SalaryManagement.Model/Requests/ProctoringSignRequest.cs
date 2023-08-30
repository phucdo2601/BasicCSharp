using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests
{
    public class ProctoringSignRequest
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public DateSign DateSign { get; set; }

        [Required]
        public List<UserSign> UserSigns { get; set; }

        public ProctoringSignRequest()
        {
            DateSign = new();
            UserSigns = new();
        }
    }

    public class DateSign
    {
        [Required]
        public List<DateTime?> Dates { get; set; }
        [Required]
        public List<DateTime?> StartDates { get; set; }
        [Required]
        public List<DateTime?> EndDates { get; set; }

        public DateSign()
        {
            Dates = new();
            StartDates = new();
            EndDates = new();
        }
    }

    public class UserSign
    {
        public string AccountFE { get; set; }
        [Required]
        public List<int?> TimeSlots { get; set; }
        public UserSign()
        {
            TimeSlots = new();
        }
    }


    public class ProctoringSignExcelRequest
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public DateProctoringSign DateProctoringSign { get; set; }

        [Required]
        public List<UserSign> UserSigns { get; set; }

        public ProctoringSignExcelRequest()
        {
            DateProctoringSign = new();
            UserSigns = new();
        }
    }

    public class DateProctoringSign
    {
        [Required]
        public List<DateTime?> StartDates { get; set; }
        [Required]
        public List<DateTime?> EndDates { get; set; }

        public DateProctoringSign()
        {
            StartDates = new();
            EndDates = new();
        }
    }

    public class UserProcRequest
    {
        [Required]
        public string SecretKey { get; set; }

        [Required]
        public string UserId { get; set; }
    }

    public class DateProcRequest
    {
        [Required]
        public string SecretKey { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }

    public class DateUserRequest
    {
        [Required]
        public string SecretKey { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
