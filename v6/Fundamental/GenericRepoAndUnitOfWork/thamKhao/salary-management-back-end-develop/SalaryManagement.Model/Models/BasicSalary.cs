using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class BasicSalary
    {
        public string BasicSalaryId { get; set; }
        public string BasicSalaryLevel { get; set; }
        public double Salary { get; set; }
        public double TimeLearningLimit { get; set; }
        public bool IsDisable { get; set; }
    }
}
