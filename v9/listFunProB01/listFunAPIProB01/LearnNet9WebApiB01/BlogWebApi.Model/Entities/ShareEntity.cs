using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "shares_tbl")]
    public class ShareEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        public UserEntity UserEntity { get; set; }
        public BlogEntity BlogEntity { get; set; }
    }
}
