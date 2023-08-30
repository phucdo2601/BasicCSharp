using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Admin
    {
        public string AdminId { get; set; }
        public string GeneralUserInfoId { get; set; }

        public virtual GeneralUserInfo GeneralUserInfo { get; set; }
    }
}
