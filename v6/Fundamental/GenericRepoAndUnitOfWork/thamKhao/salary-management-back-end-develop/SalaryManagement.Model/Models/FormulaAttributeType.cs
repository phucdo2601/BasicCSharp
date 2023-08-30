using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class FormulaAttributeType
    {
        public FormulaAttributeType()
        {
            FormulaAttributes = new HashSet<FormulaAttribute>();
        }

        public string FormulaAttributeTypeId { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormulaAttribute> FormulaAttributes { get; set; }
    }
}
