using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnBaProMvcb01.Models
{
    public class Employee
    {
        [Key]
        public int IdEmp { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(250)")]
        public string NameEmp { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(250)")]
        public string Position { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.Date)]
        public string EnrollDate { get; set; }

        public int IdDept { get; set; }

        public Department Department { get; set; }
    }
}
