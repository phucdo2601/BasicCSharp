using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class PayPolicy
    {
        public PayPolicy()
        {
            Formulas = new HashSet<Formula>();
            PayPeriods = new HashSet<PayPeriod>();
        }

        public string PayPolicyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<Formula> Formulas { get; set; }
        [JsonIgnore]
        public virtual ICollection<PayPeriod> PayPeriods { get; set; }
    }
}
