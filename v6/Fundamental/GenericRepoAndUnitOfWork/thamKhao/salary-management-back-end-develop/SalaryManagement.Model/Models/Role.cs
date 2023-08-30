using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Role
    {
        public Role()
        {
            GeneralUserInfos = new HashSet<GeneralUserInfo>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]
        public virtual ICollection<GeneralUserInfo> GeneralUserInfos { get; set; }
    }
}
