using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.BlogCategoríes;
using BlogWebApi.Domain.Services.BlogCategories;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<BlogCategoryEntity> _blogCategoryRepo;
        private readonly IBlogCategoryService _blogCateService;

        public BlogCategoryController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _blogCategoryRepo = new GenericRepository<BlogCategoryEntity>(_context);
            _blogCateService = new BlogCategoryService(_context, _unitOfWork, _blogCategoryRepo);
        }

        [HttpGet("getAllBlogCates")]
        public async Task<IActionResult> GetAllBlogCategory()
        {
            var listBlogCate = _blogCateService.FindAll();
            return listBlogCate.ToList().Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, listBlogCate))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Blog Categories" }));
        }

        [HttpGet("GetBlogCateById/{blogCateId}")]
        public async Task<IActionResult> GetBlogCateById([FromRoute(Name = "blogCateId")] string id)
        {
            try
            {
                var getBlogCateById = _blogCateService.FindById(Guid.Parse(id));
                return getBlogCateById != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, getBlogCateById))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
            }
            catch (Exception)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpPost("addNewBlogCate")]
        public async Task<IActionResult> AddNewBlogCate([FromBody] CreateBlogCategoryDto model)
        {
            if (model.BlogCategoryTitle == null)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The blog category title is not null" }));
            }
            var blogCateId = Guid.NewGuid();
            BlogCategoryEntity entity = new BlogCategoryEntity()
            {
                Id = blogCateId,
                BlogCategoryTitle = model.BlogCategoryTitle,
                DateOfCreated = DateTime.UtcNow,
                DateOfModified = DateTime.UtcNow,
            };
            var res = _blogCateService.Create(entity);
            BlogCategoryEntity blogCate = _blogCateService.FindById(entity.Id);
            if (res > 0)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, blogCate));
            }
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));
        }

        [HttpPut("UpdateBlogCategory/{blogCateId}")]
        public async Task<IActionResult> UpdateBlogCategory([FromRoute(Name = "blogCateId")] string id, [FromBody] CreateBlogCategoryDto model)
        {
            try
            {
                var blogCateId = Guid.Parse(id);
                BlogCategoryEntity existedBlogCate = _blogCateService.FindById(blogCateId);
                if (existedBlogCate == null)
                {
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
                }

                existedBlogCate.Id = blogCateId;
                existedBlogCate.BlogCategoryTitle = model.BlogCategoryTitle;
                existedBlogCate.DateOfModified = DateTime.Now;
                int updatedBlogCate = _blogCateService.Update(existedBlogCate);
                if (updatedBlogCate > 0)
                {
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, existedBlogCate));
                }

                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update Category is not successfully" }));
            }
            catch (Exception)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("DeleteBlogCategory/{blogCateId}")]
        public async Task<IActionResult> DeleteBlogCategory([FromRoute(Name = "blogCateId")] string id)
        {
            try
            {
                var blogCateId = Guid.Parse(id);
                BlogCategoryEntity existedBlogCate = _blogCateService.FindById(blogCateId);
                if (existedBlogCate == null)
                {
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
                }
                bool isDeleted = _blogCateService.Delete(existedBlogCate);
                if (isDeleted)
                {
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Blog Category is successfully!" }));
                }
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Blog Category is failed!" }));
            }
            catch (Exception)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
