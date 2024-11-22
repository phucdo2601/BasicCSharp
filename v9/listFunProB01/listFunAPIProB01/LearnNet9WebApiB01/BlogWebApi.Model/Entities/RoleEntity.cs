using System.ComponentModel.DataAnnotations.Schema;

namespace BlogWebApi.Model.Entities
{
    [Table(name: "roles_tbl")]
    public class RoleEntity : BaseEntity
    {
        public string RoleTitle { get; set; }
        public ICollection<UserEntity> UserEntities { get; set; }
    }
}
