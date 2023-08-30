using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Fesalary
    {
        public string FesalaryId { get; set; }
        public string FesalaryCode { get; set; }
        public double Salary { get; set; }
        public bool IsDisable { get; set; }
    }
}
