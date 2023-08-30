using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class SemesterSchoolType
    {
        public string SemesterSchoolTypeId { get; set; }
        public string SemesterId { get; set; }
        public string SchoolTypeId { get; set; }
        public bool IsDisable { get; set; }

        public virtual SchoolType SchoolType { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
