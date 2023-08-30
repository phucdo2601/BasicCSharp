using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class School
    {
        public School()
        {
            Departments = new HashSet<Department>();
        }

        public string SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string Address { get; set; }
        public bool IsDisable { get; set; }
        public string SchoolTypeId { get; set; }

        public virtual SchoolType SchoolType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
