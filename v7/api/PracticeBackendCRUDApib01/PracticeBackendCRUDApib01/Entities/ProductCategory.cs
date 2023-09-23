using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    [Table(name:"ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductCateName { get; set; }

        public string Status { get; set; }

        public List<Product> Products { get;}
    }
}
