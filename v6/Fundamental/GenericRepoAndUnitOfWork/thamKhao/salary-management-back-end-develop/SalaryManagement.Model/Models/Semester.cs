using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Semester
    {
        public Semester()
        {
            PayPeriods = new HashSet<PayPeriod>();
            SemesterSchoolTypes = new HashSet<SemesterSchoolType>();
        }

        public string SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<PayPeriod> PayPeriods { get; set; }
        [JsonIgnore]
        public virtual ICollection<SemesterSchoolType> SemesterSchoolTypes { get; set; }
    }
}
