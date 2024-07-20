using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.StaffRole
{
    public class UpdateStaffRoleReqDto
    {
        public Guid Id { get; set; }
        public string StaffRoleCode { get; set; }
        public string StaffRoleTitle { get; set; }
    }
}
