using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnNet6ApiUploadFileb01.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
