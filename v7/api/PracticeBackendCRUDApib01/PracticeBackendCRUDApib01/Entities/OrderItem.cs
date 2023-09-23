using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public DateTime? GettingDate { get; set; }
        public Guid StatusId { get; set; }

        public Guid? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
