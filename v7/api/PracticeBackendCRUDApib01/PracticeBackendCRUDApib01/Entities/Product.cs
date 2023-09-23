using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string status { get; set; }
        public Guid ProductCateId { get; set; }
        public Guid ShopId { get; set; }

        [ForeignKey("ProductCateId")]
        public ProductCategory ProductCategory { get; set; }

        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }

        public List<CartItem> CartItems { get; set; }
        public List<ProductService> ProductServices { get; set; }
    }
}
