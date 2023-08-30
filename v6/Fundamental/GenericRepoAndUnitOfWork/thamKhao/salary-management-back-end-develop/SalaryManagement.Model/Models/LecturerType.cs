using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class LecturerType
    {
        public LecturerType()
        {
            Lecturers = new HashSet<Lecturer>();
            SalaryHistories = new HashSet<SalaryHistory>();
        }

        public string LecturerTypeId { get; set; }
        public string LecturerTypeName { get; set; }
        public int StatisticsStartDay { get; set; }
        public int StatisticsEndDay { get; set; }
        public int PayDay { get; set; }
        public string FormulaId { get; set; }

        public virtual Formula Formula { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        [JsonIgnore]
        public virtual ICollection<SalaryHistory> SalaryHistories { get; set; }
    }
}
