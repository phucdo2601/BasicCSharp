using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "users_tbl")]
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passord { get; set; }
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public Guid RoleId { get; set; }

        public RoleEntity RoleEntity { get; set; }
        public ICollection<BlogEntity> BlogEntities { get; set; }
        public ICollection<CommentEntity> CommentEntities { get; set; }
        public ICollection<LikeEntity> LikeEntities { get; set; }
        public ICollection<ShareEntity> ShareEntities { get; set; }
        public ICollection<InteractionEntity> InteractionEntities { get; set; }
    }
}
