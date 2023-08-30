using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class PayPeriod
    {
        public PayPeriod()
        {
            PaySlips = new HashSet<PaySlip>();
        }

        public string PayPeriodId { get; set; }
        public string PayPeriodName { get; set; }
        public DateTime CreateDate { get; set; }
        public string PayPolicyId { get; set; }
        public string SemesterId { get; set; }

        public virtual PayPolicy PayPolicy { get; set; }
        public virtual Semester Semester { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaySlip> PaySlips { get; set; }
    }
}
