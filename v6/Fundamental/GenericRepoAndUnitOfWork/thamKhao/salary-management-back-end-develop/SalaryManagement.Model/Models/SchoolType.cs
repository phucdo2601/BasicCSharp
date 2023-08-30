using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class SchoolType
    {
        public SchoolType()
        {
            Schools = new HashSet<School>();
            SemesterSchoolTypes = new HashSet<SemesterSchoolType>();
        }

        public string SchoolTypeId { get; set; }
        public string SchoolTypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<School> Schools { get; set; }
        [JsonIgnore]
        public virtual ICollection<SemesterSchoolType> SemesterSchoolTypes { get; set; }
    }
}
