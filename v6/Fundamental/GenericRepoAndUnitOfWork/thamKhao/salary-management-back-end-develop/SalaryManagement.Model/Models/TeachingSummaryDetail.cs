using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class TeachingSummaryDetail
    {
        public string TeachingSummaryDetailId { get; set; }
        public DateTime Date { get; set; }
        public int Slot { get; set; }
        public string Room { get; set; }
        public string Course { get; set; }
        public int? SessionNo { get; set; }
        public string Student { get; set; }
        public string Attendance { get; set; }
        public string TeachingSummaryId { get; set; }

        public virtual TeachingSummary TeachingSummary { get; set; }
    }
}
