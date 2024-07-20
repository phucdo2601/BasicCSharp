using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracNet7ApiProB01.Dto.Dtos.GeneralRole;
using PracNet7ApiProB01.Dto.Dtos.ProductBrand;
using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Model.Repositories.ProductBrandRepository;
using PracNet7ApiProB01.Services.EntityServices.ProductBrandService;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PracNet7ApiProB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly PracNet7ApiDbContext _context;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IProductBrandService _productBrandService;

        public ProductBrandController(IUnitOfWork _iUnitOfWork, PracNet7ApiDbContext _context)
        {
            this._iUnitOfWork = _iUnitOfWork;
            this._context = _context;
            this._productBrandRepo = new ProductBrandRepository(_context);
            this._productBrandService = new ProductBrandService(_context, _iUnitOfWork,_productBrandRepo);
        }


        #region Get All ProductBrand
        [HttpGet("getAllProBrands")]
        public async Task<IActionResult> GetAllProBrands()
        {
            List<ProductBrand> productBrands = _productBrandService.FindAll();
            Log.Information("Get All ProductBrands list on {@var1} and {@var2}", DateTime.Now, productBrands);

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, productBrands));
        }
        #endregion

        #region Get ProductBrand by Id
        [HttpGet("getProBrandById/{proBrandId}")]
        public async Task<IActionResult> GetGenRoleById([FromRoute(Name = "proBrandId")] string id)
        {
            Guid proBrandId = Guid.Parse(id);
            ProductBrand productBrand = _productBrandService.FindById(proBrandId);
            Log.Information("Get productBrand by id {@var1} list on {@var2} and {@var3}", id, DateTime.Now, productBrand);
            return productBrand != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, productBrand)) :
                    await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Product Brand with {id} does not exist." }));
        }

        #endregion

        #region Create New ProductBrand
        [HttpPost("createNewProBrand")]
        public async Task<IActionResult> CreateNewProBrand([FromBody] CreateProductBrandReqDto proBrandRequest)
        {

            CommonResponseDto<ProductBrand> created = (CommonResponseDto<ProductBrand>)await _productBrandService.CreateNewProductBrand(proBrandRequest);
            Console.WriteLine(created);
            if (created.Data != null)
            {
                created.StatusCode = StatusCodes.Status201Created;
                Log.Information("Created ProductBrand on {@var1} and {@var2}", DateTime.Now, created);
                return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new
                {
                    StatusCode = StatusCodes.Status201Created,
                    ResponseModel = created,
                }));
            }
            else
            {
                created.StatusCode = StatusCodes.Status400BadRequest;
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = created }));
            }
        }


        #endregion

        #region Update ProductBrand By Id
        [HttpPut("updateProBrand/{proBrandId}")]
        public async Task<IActionResult> UpdateGenCodeById([FromRoute(Name = "proBrandId")] string id, [FromBody] UpdateProductBrandReqDto model)
        {
            CommonResponseDto<ProductBrand> updated = (CommonResponseDto<ProductBrand>)await _productBrandService.UpdateProductBrand(id, model);

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
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = updated }));
            }

        }

        #endregion

        #region DeleteProBrand by Id 
        [HttpDelete("deleteProBrand/{proBrandId}")]
        public async Task<IActionResult> DeleteProBrand([FromRoute(Name = "proBrandId")] string id)
        {
            CommonResponseDto<ProductBrand> deleted = (CommonResponseDto<ProductBrand>)await _productBrandService.DeleteProductBrand(id);

            if (deleted.StatusCode == StatusCodes.Status200OK)
            {
                Log.Information("Delete ProductBrand with id {@var1} on {@var2} Success", id, DateTime.Now);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
                {
                    StatusCode = StatusCodes.Status200OK,
                    ResponseModel = deleted
                }));
            }
            else
            {
                deleted.StatusCode = StatusCodes.Status400BadRequest;
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = deleted }));
            }
        }
        #endregion
    }
}
