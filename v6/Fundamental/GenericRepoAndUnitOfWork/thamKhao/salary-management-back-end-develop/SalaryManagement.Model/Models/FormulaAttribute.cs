using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class FormulaAttribute
    {
        public FormulaAttribute()
        {
            FormulaAttributeDepartments = new HashSet<FormulaAttributeDepartment>();
            FormulaAttributeFormulas = new HashSet<FormulaAttributeFormula>();
            PaySlipItems = new HashSet<PaySlipItem>();
        }

        public string FormulaAttributeId { get; set; }
        public string Attribute { get; set; }
        public double? Value { get; set; }
        public string AttributeName { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }
        public double? Limit { get; set; }
        public string FormulaAttributeTypeId { get; set; }
        public string GroupAttributeId { get; set; }

        [NotMapped]
        public List<Department> Departments { get; set; }

        public virtual FormulaAttributeType FormulaAttributeType { get; set; }
        public virtual GroupAttribute GroupAttribute { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormulaAttributeDepartment> FormulaAttributeDepartments { get; set; }
        [JsonIgnore]
        public virtual ICollection<FormulaAttributeFormula> FormulaAttributeFormulas { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaySlipItem> PaySlipItems { get; set; }
    }
}
