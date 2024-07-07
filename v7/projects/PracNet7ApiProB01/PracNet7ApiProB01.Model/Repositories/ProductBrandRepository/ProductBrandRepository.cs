using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracNet7ApiProB01.Model.Repositories.ProductBrandRepository
{
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        private readonly PracNet7ApiDbContext _context;
        public ProductBrandRepository(PracNet7ApiDbContext _context) : base(_context)
        {
            this._context = _context;
        }
    }
}
