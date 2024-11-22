using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "blogs_tbl")]
    public class BlogEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public Guid BlogCategoryId { get; set; }
        public Guid UserId { get; set; }
        public BlogCategoryEntity BlogCategory { get; set; }
        public UserEntity UserEntity { get; set; }
        public ICollection<CommentEntity> CommentEntities { get; set; }
        public ICollection<LikeEntity> LikeEntities { get; set; }
        public ICollection<ShareEntity> ShareEntities { get; set; }
        public ICollection<InteractionEntity> InteractionEntities { get; set; }
    }
}
