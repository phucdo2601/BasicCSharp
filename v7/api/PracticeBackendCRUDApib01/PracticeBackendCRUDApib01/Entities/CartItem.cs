using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; }
        public DateTime AddedTime{ get; set; }
        public DateTime DeletedTime { get; set; }
        public Guid StatusId { get; set; }

        public int Quantity { get; set; }

        public float CartItemPrice { get; set; }
        public bool? IsDiscount { get; set; }

        public Guid? ProductId { get; set; }
        public Guid? CartId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
    }
}
