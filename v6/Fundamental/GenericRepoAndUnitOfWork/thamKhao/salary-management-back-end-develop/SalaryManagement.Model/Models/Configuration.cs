using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Configuration
    {
        public string ConfigurationId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
