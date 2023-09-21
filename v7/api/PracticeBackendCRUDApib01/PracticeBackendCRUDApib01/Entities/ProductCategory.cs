using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeBackendCRUDApib01.Entities
{
    [Table(name:"ProductCategory")]
    public class ProductCategory
    {
        public int Id { get; set; }
        public string ProductCateName { get; set; }

        public string Status { get; set; }

        public List<Product> Products { get;}
    }
}
