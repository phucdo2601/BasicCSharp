using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class FormulaAttributeFormula
    {
        public string FormulaAttributeFormulaId { get; set; }
        public string FormulaId { get; set; }
        public string FormulaAttributeId { get; set; }

        public virtual Formula Formula { get; set; }
        public virtual FormulaAttribute FormulaAttribute { get; set; }
    }
}
