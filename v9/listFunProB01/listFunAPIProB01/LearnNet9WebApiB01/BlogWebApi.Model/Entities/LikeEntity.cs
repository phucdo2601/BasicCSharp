using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "likes_tbl")]
    public class LikeEntity : BaseEntity
    {
        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }

        public BlogEntity BlogEntity { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
