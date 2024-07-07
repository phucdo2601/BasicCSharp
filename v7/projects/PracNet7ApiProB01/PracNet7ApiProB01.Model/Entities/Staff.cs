using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    [Table(name: "staffs_tbl")]
    public class Staff : BaseEntity
    {
        public string StaffRoleCode { get; set; }
        public string StaffRoleTitle { get; set; }
        public Guid StaffRoleId { get; set; }
        public StaffRole StaffRole { get; set; }

        /**
         * Making 1-TO-1 between Staff and GeneralUserInfo
         * GeneralUserInfoId is ForeignKey => Staff entity includes one GeneralUserInfo
         */
        public Guid GenUserInfoId { get; set; }
        public GeneralUserInfo GeneralUserInfo { get; set; }
    }
}
