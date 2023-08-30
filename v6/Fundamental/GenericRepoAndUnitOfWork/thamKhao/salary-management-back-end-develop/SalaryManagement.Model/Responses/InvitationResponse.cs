using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Responses
{
    public class InvitationResponse
    {
        [Required]
        public string Status { set; get; }

        [Required]
        public List<String> Success { set; get; }
        [Required]
        public List<String> Error { set; get; }
    }
}
