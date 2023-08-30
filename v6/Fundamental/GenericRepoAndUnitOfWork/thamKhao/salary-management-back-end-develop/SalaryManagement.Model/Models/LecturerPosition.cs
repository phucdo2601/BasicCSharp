using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class LecturerPosition
    {
        public LecturerPosition()
        {
            LecturerDepartments = new HashSet<LecturerDepartment>();
        }

        public string LecturerPositionId { get; set; }
        public string LecturerPositionName { get; set; }

        [JsonIgnore]
        public virtual ICollection<LecturerDepartment> LecturerDepartments { get; set; }
    }
}
