using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    [Table(name: "general_user_info_tbl")]
    public class GeneralUserInfo : BaseEntity
    {
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Boolean IsActive { get; set; }
        public string NationalId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public Guid GenRoleId { get; set; }
        public GeneralRole GeneralRole { get; set; }

        /**
         * Making 1-TO-1 between Customer and GeneralUserInfo
         * GeneralUserInfoId is ForeignKey => GeneralUserInfo entity includes one Customer
         */
        public Customer Customer { get; set; }

        /**
         * Making 1-TO-1 between Staff and GeneralUserInfo
         * GeneralUserInfoId is ForeignKey => GeneralUserInfo entity includes one Staff
         */
        public Staff Staff { get; set; }
    }
}
