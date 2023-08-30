using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet5EntityFrameB01.Data
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
