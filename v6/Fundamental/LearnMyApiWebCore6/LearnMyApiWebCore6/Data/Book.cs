using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnMyApiWebCore6.Data
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Range(0,double.MaxValue)]
        public double price { get; set; }
        [Range(0, 1000)]
        public int Quantity { get; set; }
    }
}
