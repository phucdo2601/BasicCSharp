using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.GeneralRole
{
    public class CreateGeneralRoleReqDro
    {
        public required string GenRoleCode { get; set; }
        public required string GenRoleTitle { get; set; }
    }
}
