using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    public class ProductService
    {
        public Guid ProductServiceId { get; set; }
        public Guid ProductId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid? StatusId{ get; set; }
        public DateTime? UpdateDate { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}
