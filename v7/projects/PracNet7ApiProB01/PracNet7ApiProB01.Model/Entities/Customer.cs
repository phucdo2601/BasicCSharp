using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{
    [Table(name: "customes_tbl")]
    public class Customer : BaseEntity
    {
        public string CustomerCode { get; set; }
        public float CustomerPoint { get; set; }
        public DateTime? LastPurchaseDate { get; set; }

        /**
         * Making 1-TO-1 between Customer and GeneralUserInfo
         * GeneralUserInfoId is ForeignKey => Customer entity includes one GeneralUserInfo
         */
        public Guid GenUserInfoId { get; set; }
        public GeneralUserInfo GeneralUserInfo { get; set; }
    }

}
