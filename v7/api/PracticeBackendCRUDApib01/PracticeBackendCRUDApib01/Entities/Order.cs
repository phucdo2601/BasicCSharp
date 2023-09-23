using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? CanceledDate { get; set; }

        public DateTime? ExpectedGetDate { get; set; }
        public DateTime? SuccessDate { get; set; }

        public Guid? StatusId { get; set; }


        public Guid CartId{ get; set; }

        [ForeignKey("CartId")]
        public Cart Cart { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
