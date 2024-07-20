using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PracNet7ApiProB01.Dto.Dtos.Product;
using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Model.Repositories.ProductRepository;
using PracNet7ApiProB01.Services.EntityServices.ProductService;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PracNet7ApiProB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PracNet7ApiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;

        public ProductController(IUnitOfWork unitOfWork, PracNet7ApiDbContext context)
        {
            this._context = context;
            this._unitOfWork = unitOfWork;
            this._productRepository = new ProductRepository(_context);
            this._productService = new ProductService(_context, _unitOfWork, this._productRepository);
        }


        #region Get All Products
        [HttpGet("getAllPros")]
        public async Task<IActionResult> GetAllProducts()
        {
            List<Product> products = _productService.FindAll();
            Log.Information("Get All Products list on {@var1} and {@var2}", DateTime.Now, products);
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, products));
        }

        #endregion

        #region Get Product by Id
        [HttpGet("getProById/{proId}")]
        public async Task<IActionResult> GetProductById([FromRoute(Name = "proId")] string id)
        {
            Guid proId = Guid.Parse(id);
            Product product = _productService.FindById(proId);
            Log.Information("Get  Product by id {@var1} list on {@var2} and {@var3}", id, DateTime.Now, product);
            return product != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, product)) :
                    await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Product with {id} does not exist." }));
        }
        #endregion

        #region Create New Product
        [HttpPost("createNewPro")]
        public async Task<IActionResult> CreateNewPro([FromBody] CreateProductReqDto proRequest)
        {
            CommonResponseDto<Product> created = (CommonResponseDto<Product>) await _productService.CreateNewProduct(proRequest);
            if (created.Data != null)
            {
                created.StatusCode = StatusCodes.Status201Created;
                Log.Information("Create new Product on {@var1} and {@var2}b Success", DateTime.Now, created);
                return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new
                {
                    StatusCode = StatusCodes.Status201Created,
                    ResponseModel = created
                }));
            }
            else
            {
                created.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Create new Product on {@var1} and {@var2} Failed", DateTime.Now, created);
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = created }));
            }
        }
        #endregion

        #region Update product by id
        [HttpPut("updatePro/{proId}")]
        public async Task<IActionResult> UpdateProById([FromRoute(Name = "proId")] string id, [FromBody] UpdateProductReqDto model)
        {
            CommonResponseDto<Product> updated = (CommonResponseDto<Product>) await _productService.UpdateProduct(id, model);

            if (updated.Data != null)
            {
                updated.StatusCode = 200;
                Log.Information("Update Product with id {@var1} on {@var2} and {@var3} Success", id, DateTime.Now, updated);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
                {
                    StatusCode = StatusCodes.Status200OK,
                    ResponseModel = updated
                }));
            }
            else
            {
                updated.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Update Product with id {@var1} on {@var2} and {@var3 Failed}", id, DateTime.Now, updated);
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = updated }));
            }
        }
        #endregion

        #region  Delete Product by Id
        [HttpDelete("deletePro/{proBId}")]
        public async Task<IActionResult> DeletePro([FromRoute(Name = "proBId")] string id)
        {
            CommonResponseDto<Product> deleted = (CommonResponseDto<Product>)await _productService.DeleteProduct(id);

            if (deleted.StatusCode == StatusCodes.Status200OK)
            {
                Log.Information("Delete Product with id {@var1} on {@var2} Success", id, DateTime.Now);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
                {
                    StatusCode = StatusCodes.Status200OK,
                    ResponseModel = deleted
                }));
            }
            else
            {
                deleted.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Delete Product with id {@var1} on {@var2} Failed", id, DateTime.Now);
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = deleted }));
            }
        }
        #endregion

        #region Get All Products With All Sub Objects
        [HttpGet("getAllProsInclude")]
        public async Task<IActionResult> GetAllProInclude()
        {
            var products = _productService.GetAllProductsWithSubObject();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, products));
        }

        #endregion
    }
}
