using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class GroupAttribute
    {
        public GroupAttribute()
        {
            FormulaAttributes = new HashSet<FormulaAttribute>();
        }

        public string GroupAttributeId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }

        [JsonIgnore]
        public virtual ICollection<FormulaAttribute> FormulaAttributes { get; set; }
    }
}
