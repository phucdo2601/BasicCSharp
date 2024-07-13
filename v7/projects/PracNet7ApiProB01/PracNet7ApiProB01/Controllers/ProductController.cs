using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Model.Repositories.ProductRepository;
using PracNet7ApiProB01.Services.EntityServices.ProductService;

namespace PracNet7ApiProB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly UnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(IUnitOfWork unitOfWork, PracNet7ApiDbContext context, IGenericRepository<Product> repository, IGenericService<Product> service) : base(unitOfWork, context, repository, service)
        {
            this._context = context;
            //this._uni
        }

    }
}
