using LearnNet6ApiUploadFileb01.Models;
using LearnNet6ApiUploadFileb01.Repositories.Abstract;

namespace LearnNet6ApiUploadFileb01.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Product model)
        {
            try
            {
                _context.Products.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
