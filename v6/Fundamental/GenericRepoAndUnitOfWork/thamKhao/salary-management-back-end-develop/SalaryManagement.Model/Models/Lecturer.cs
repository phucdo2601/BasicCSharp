using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class Lecturer
    {
        public Lecturer()
        {
            LecturerDepartments = new HashSet<LecturerDepartment>();
            PaySlips = new HashSet<PaySlip>();
            ProctoringSigns = new HashSet<ProctoringSign>();
            SalaryHistories = new HashSet<SalaryHistory>();
        }

        public string LecturerId { get; set; }
        public string LecturerCode { get; set; }
        public string LecturerTypeId { get; set; }
        [Encrypted]
        public string BasicSalaryId { get; set; }
        [Encrypted]
        public string FesalaryId { get; set; }
        public string GeneralUserInfoId { get; set; }

        [NotMapped]
        public BasicSalary BasicSalary { get; set; }
        [NotMapped]
        public Fesalary Fesalary { get; set; }

        public virtual GeneralUserInfo GeneralUserInfo { get; set; }
        public virtual LecturerType LecturerType { get; set; }

        [JsonIgnore]
        public virtual ICollection<LecturerDepartment> LecturerDepartments { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaySlip> PaySlips { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProctoringSign> ProctoringSigns { get; set; }
        [JsonIgnore]
        public virtual ICollection<SalaryHistory> SalaryHistories { get; set; }
    }
}
