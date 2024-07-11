using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.Product
{
    public class UpdateProductReqDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public float OriginalPrice { get; set; }
        public float ProductCode { get; set; }
        public float ProductName { get; set; }
        public int Quantity { get; set; }
        public string StatusId { get; set; }
        public Guid ProductBrandId { get; set; }
    }
}
