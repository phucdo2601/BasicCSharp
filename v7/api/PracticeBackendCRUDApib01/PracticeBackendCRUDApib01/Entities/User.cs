using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DisplayName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid StatusId { get; set; }
        public string Description { get; set; }

        public Guid UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public UserRole UserRole { get; set; }

        public List<Shop> Shops { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
