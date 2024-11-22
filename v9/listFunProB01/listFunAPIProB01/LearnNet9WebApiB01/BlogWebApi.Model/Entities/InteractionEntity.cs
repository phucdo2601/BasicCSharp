using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "interaction_tbl")]
    public class InteractionEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
        public Guid InteractionTypeId { get; set; }

        public UserEntity UserEntity { get; set; }
        public BlogEntity BlogEntity { get; set; }
        public InteractionTypeEntity InteractionTypeEntity { get; set; }
    }
}
