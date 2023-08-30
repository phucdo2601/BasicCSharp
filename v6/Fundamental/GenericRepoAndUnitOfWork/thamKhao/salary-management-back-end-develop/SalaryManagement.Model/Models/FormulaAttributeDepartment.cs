using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class FormulaAttributeDepartment
    {
        public string FormulaAttributeDepartmentId { get; set; }
        public string DepartmentId { get; set; }
        public string FormulaAttributeId { get; set; }

        public virtual Department Department { get; set; }
        public virtual FormulaAttribute FormulaAttribute { get; set; }
    }
}
