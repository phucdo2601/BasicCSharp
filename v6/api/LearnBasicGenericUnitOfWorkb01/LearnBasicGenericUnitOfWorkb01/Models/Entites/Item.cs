
namespace LearnBasicGenericUnitOfWorkb01.Models.Entites
{
    public class Item
    { 
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public string Description { get; set; }

        public double? Rating { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set;}

        public bool IsActivate { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
