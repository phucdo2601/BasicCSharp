using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class TeachingSummary
    {
        public TeachingSummary()
        {
            TeachingSummaryDetails = new HashSet<TeachingSummaryDetail>();
        }

        public string TeachingSummaryId { get; set; }
        public int AttendedTeaching { get; set; }
        public int PlanTeaching { get; set; }
        public double Average { get; set; }
        public int TotalDay { get; set; }
        public double TotalWeek { get; set; }
        public string PaySlipId { get; set; }

        public virtual PaySlip PaySlip { get; set; }
        [JsonIgnore]
        public virtual ICollection<TeachingSummaryDetail> TeachingSummaryDetails { get; set; }
    }
}
