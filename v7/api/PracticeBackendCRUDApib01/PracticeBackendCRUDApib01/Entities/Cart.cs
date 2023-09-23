using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class Cart
    {
        [Key]
        public Guid CartId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid StatusId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<CartItem> CartItems { get; set;}
        public List<Order> Orders { get; set; }
    }
}
