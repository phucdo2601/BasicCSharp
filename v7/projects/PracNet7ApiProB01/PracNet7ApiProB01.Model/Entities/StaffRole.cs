using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    [Table(name: "staff_roles_tbl")]
    public class StaffRole : BaseEntity
    {
        public string StaffRoleCode { get; set; }
        public string StaffRoleTitle { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
