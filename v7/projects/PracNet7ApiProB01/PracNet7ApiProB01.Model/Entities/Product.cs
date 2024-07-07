using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Entities
{

    public class Product : BaseEntity
    {
        public DateTime? DateOfCreate { get; set; }
        public DateTime? DateOfUpdate { get; set; }
        public string Description { get; set; }
        public float OriginalPrice { get; set; }
        public float ProductCode { get; set; }
        public float ProductName { get; set; }
        public int Quantity { get; set; }
        public string StatusId { get; set; }
        public Guid ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

    }
}
