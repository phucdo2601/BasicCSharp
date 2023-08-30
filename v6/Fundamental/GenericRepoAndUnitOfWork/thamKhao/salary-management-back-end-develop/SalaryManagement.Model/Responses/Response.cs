using SalaryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Responses
{
    public class Response
    {
        [Required]
        public int StatusCode { get; set; }

        [Required]
        public string Status { set; get; }

        public string Message { set; get; }

        public object Data { get; set; }
    }

    public static class StatusResponse
    {
        public const string Success = "Success";
        public const string Failed = "Failed";
    }

    public class ErrorItem
    {
        public string ErrorName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public GeneralUserInfo ResponseData { get; set; }
    }
}