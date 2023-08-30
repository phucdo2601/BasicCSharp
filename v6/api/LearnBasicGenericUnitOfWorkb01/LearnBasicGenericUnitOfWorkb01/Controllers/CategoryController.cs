using LearnBasicGenericUnitOfWorkb01.Dtos.Request;
using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using LearnBasicGenericUnitOfWorkb01.Services.Categories;
using LearnBasicGenericUnitOfWorkb01.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnBasicGenericUnitOfWorkb01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;
        private readonly DatabaseContext _context;

        public CategoryController(IUnitOfWork unitOfWork, DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _categoryService = new CategoryService(unitOfWork, _context);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories() { 
            
            var listCategory = _categoryService.GetAllCategories();
            return listCategory.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, listCategory))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new {StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Categories"}));
        }

        [HttpGet("GetCateById/{cateId}")]
        public async Task<IActionResult> GetCateById([FromRoute(Name ="cateId")] int cateId)
        {
            var getCateById = _categoryService.GetCategoryById(cateId);
            return getCateById != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, getCateById))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Category with id {cateId}" }));
        }

        [HttpPost("addNewCategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] CategoryRequestModel model)
        {
            if (model.CategoryName == null) {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The category name is not null" }));
            }

            var res = _categoryService.CreateCategory(model);
            
            return res > 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, res))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));
        }

        [HttpPut("updateCate/{cateId}")]
        public async Task<IActionResult> UpdateCategory([FromRoute(Name = "cateId")] int cateId, [FromBody] CategoryRequestModel model)
        { 
            var res = _categoryService.UpdateCategory(cateId, model);
            return res > 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, res))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));
        }
    }
}
