using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class PaySlip
    {
        public PaySlip()
        {
            PaySlipItems = new HashSet<PaySlipItem>();
        }

        public string PaySlipId { get; set; }
        public string PaySlipName { get; set; }
        public string CalculationFormula { get; set; }
        [JsonIgnore]
        [Encrypted]
        public string TotalEncrypt { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string FormulaId { get; set; }
        public string PayPeriodId { get; set; }
        public string LecturerId { get; set; }

        [NotMapped]
        public double Total
        {
            get { return double.Parse(TotalEncrypt); }
            set { }
        }

        public virtual Formula Formula { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual PayPeriod PayPeriod { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaySlipItem> PaySlipItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<TeachingSummary> TeachingSummaries { get; set; }
    }
}
