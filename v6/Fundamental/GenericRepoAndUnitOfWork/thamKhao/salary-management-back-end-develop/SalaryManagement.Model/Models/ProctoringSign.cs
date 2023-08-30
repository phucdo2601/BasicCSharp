using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class ProctoringSign
    {
        public string ProctoringSignId { get; set; }
        public string TimeSlotId { get; set; }
        public string LecturerId { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual TimeSlot TimeSlot { get; set; }
    }
}
