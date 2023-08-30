using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class TimeSlot
    {
        public TimeSlot()
        {
            ProctoringSigns = new HashSet<ProctoringSign>();
        }

        public string TimeSlotId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Value { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProctoringSign> ProctoringSigns { get; set; }
    }
}
