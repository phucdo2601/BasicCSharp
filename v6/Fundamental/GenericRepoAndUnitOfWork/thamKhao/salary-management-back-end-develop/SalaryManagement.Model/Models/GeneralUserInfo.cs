using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SalaryManagement.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public partial class GeneralUserInfo
    {
        public GeneralUserInfo()
        {
            Admins = new HashSet<Admin>();
            Lecturers = new HashSet<Lecturer>();
            Managers = new HashSet<Manager>();
        }

        public string GeneralUserInfoId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        [Encrypted]
        public string Password { get; set; }
        public string Gmail { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public bool IsDisable { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Admin> Admins { get; set; }
        [JsonIgnore]
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        [JsonIgnore]
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
