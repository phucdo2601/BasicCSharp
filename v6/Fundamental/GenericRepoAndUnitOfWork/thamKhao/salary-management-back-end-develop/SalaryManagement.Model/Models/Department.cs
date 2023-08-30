using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Department
    {
        public Department()
        {
            LecturerDepartments = new HashSet<LecturerDepartment>();
        }

        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDisable { get; set; }
        public string SchoolId { get; set; }

        public virtual School School { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormulaAttributeDepartment> FormulaAttributeDepartments { get; set; }
        [JsonIgnore]
        public virtual ICollection<LecturerDepartment> LecturerDepartments { get; set; }
    }
}
