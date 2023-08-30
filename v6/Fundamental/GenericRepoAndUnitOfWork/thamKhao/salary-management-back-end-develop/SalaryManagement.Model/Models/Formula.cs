using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Formula
    {
        public Formula()
        {
            FormulaAttributeFormulas = new HashSet<FormulaAttributeFormula>();
            LecturerTypes = new HashSet<LecturerType>();
            PaySlips = new HashSet<PaySlip>();
        }

        public string FormulaId { get; set; }
        public string CalculationFormula { get; set; }
        public string FormulaName { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }
        public string PayPolicyId { get; set; }

        public virtual PayPolicy PayPolicy { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormulaAttributeFormula> FormulaAttributeFormulas { get; set; }
        [JsonIgnore]
        public virtual ICollection<LecturerType> LecturerTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaySlip> PaySlips { get; set; }
    }
}
