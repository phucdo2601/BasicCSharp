using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class SalaryHistory
    {
        public string SalaryHistoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double BasicSalary { get; set; }
        public double Fesalary { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsUsing { get; set; }
        [Encrypted]
        public string BasicSalaryId { get; set; }
        [Encrypted]
        public string FesalaryId { get; set; }
        public string LecturerTypeId { get; set; }
        public string LecturerId { get; set; }

        [NotMapped]
        public BasicSalary BasicSalaryInfo { get; set; }
        [NotMapped]
        public Fesalary FesalaryInfo { get; set; }

        public virtual Lecturer Lecturer { get; set; }
        public virtual LecturerType LecturerType { get; set; }
    }
}
