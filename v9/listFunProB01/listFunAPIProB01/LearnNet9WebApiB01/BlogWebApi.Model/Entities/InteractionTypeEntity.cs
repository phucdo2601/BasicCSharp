using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "interaction_types_tbl")]
    public class InteractionTypeEntity : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<InteractionEntity> InteractionEntities { get; set; }
    }
}
