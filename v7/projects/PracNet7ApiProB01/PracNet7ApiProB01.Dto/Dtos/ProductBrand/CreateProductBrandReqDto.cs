using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.ProductBrand
{
    public class CreateProductBrandReqDto
    {
        public required string BrandCode { get; set; }
        public required string BrandNName { get; set; }
        public string? Description { get; set; }
    }
}
