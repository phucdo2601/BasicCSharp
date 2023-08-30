using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests.Login
{
    public class GmailLoginRequest
    {
        [Required]
        public string OauthIdToken { get; set; }
    }
}
