using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "comments_tbl")]
    public class CommentEntity : BaseEntity
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        public UserEntity UserEntity { get; set; }
        public BlogEntity BlogEntity { get; set; }

    }
}
