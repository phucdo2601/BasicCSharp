using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    /// <summary>
    /// <className>GeneralRole</className>
    /// <author>Phucdn</author>
    /// </summary>
    [Table(name: "general_roles_tbl")]
    public class GeneralRole : BaseEntity
    {
        public string GenRoleCode { get; set; }
        public string GenRoleTitle { get; set; }

        public ICollection<GeneralUserInfo> GeneralUserInfos { get; set; }
    }
}
