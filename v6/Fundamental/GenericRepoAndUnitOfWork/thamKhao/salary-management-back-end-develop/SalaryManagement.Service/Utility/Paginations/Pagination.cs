using System.ComponentModel.DataAnnotations;

namespace SalaryManagement.Requests.Paginations
{
    public class Pagination
    {
        [Required]
        public int PageNumber { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
