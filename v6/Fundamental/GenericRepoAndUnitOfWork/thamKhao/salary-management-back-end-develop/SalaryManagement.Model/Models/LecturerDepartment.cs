using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class LecturerDepartment
    {
        public string LecturerDepartmentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsWorking { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string LecturerPositionId { get; set; }
        public string LecturerId { get; set; }
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual LecturerPosition LecturerPosition { get; set; }
    }
}
