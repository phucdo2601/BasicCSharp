using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnBaProMvcb01.Models
{
    public class Department
    {
        [Key]
        public int IdDept { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Column(TypeName = "nvarchar(250)")]
        public string NameDept { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
