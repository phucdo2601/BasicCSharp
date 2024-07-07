using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Dto.Dtos.ProductBrand
{
    public class UpdateProductBrandReqDto
    {
        public Guid Id { get; set; }
        public string BrandCode { get; set; }
        public string BrandNName { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfUpdate { get; set; }
        public string Description { get; set; }
    }
}
