using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.GeneralRole
{
    public class UpdateGenRoleReqDto
    {
        public Guid Id { get; set; }
        public string GenRoleCode { get; set; }
        public string GenRoleTitle { get; set; }
    }
}
