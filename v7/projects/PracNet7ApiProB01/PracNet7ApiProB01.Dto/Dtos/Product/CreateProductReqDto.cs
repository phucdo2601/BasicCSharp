using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.Product
{
    public class CreateProductReqDto
    {
        public string? Description { get; set; }
        public float OriginalPrice { get; set; }
        public required string ProductCode { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
        public required string StatusId { get; set; }
        public Guid ProductBrandId { get; set; }
    }
}
