using AutoMapper;
using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.BlogCategoríes;
using BlogWebApi.Domain.Services.BlogCategories;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        private readonly ILogger<BlogCategoryController> _logger;
        private readonly IMapper _mapper;

        public BlogCategoryController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<BlogCategoryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _blogCategoryRepo = new GenericRepository<BlogCategoryEntity>(_context);
            _blogCateService = new BlogCategoryService(_context, _unitOfWork, _blogCategoryRepo);
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAllBlogCates")]
        public async Task<IActionResult> GetAllBlogCategory()
        {
            _logger.LogInformation($"Begin {nameof(GetAllBlogCategory)} function in {this.GetType().Name}");
            var listBlogCate = _blogCateService.FindAll();
            if (listBlogCate.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllBlogCategory)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listBlogCate));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllBlogCategory)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Blog Categories" }));
        }

        [HttpGet("GetBlogCateById/{blogCateId}")]
        public async Task<IActionResult> GetBlogCateById([FromRoute(Name = "blogCateId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetBlogCateById)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetBlogCateById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespace" }));
            }
            try
            {
                var getBlogCateById = _blogCateService.FindById(Guid.Parse(id));
                if (getBlogCateById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetBlogCateById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getBlogCateById));
                }
                _logger.LogError($"Not Load data of {nameof(GetBlogCateById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetBlogCateById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpPost("addNewBlogCate")]
        public async Task<IActionResult> AddNewBlogCate([FromBody] CreateBlogCategoryDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewBlogCate)} function in {this.GetType().Name}");
            if (model.BlogCategoryTitle == null)
            {
                _logger.LogError($"Not Load data of {nameof(AddNewBlogCate)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The blog category title is not null" }));
            }
            var blogCateId = Guid.NewGuid();
            BlogCategoryEntity entity = _mapper.Map<BlogCategoryEntity>(model);
            entity.Id = blogCateId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _blogCateService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewBlogCate)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewBlogCate)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));
        }

        [HttpPut("UpdateBlogCategory/{blogCateId}")]
        public async Task<IActionResult> UpdateBlogCategory([FromRoute(Name = "blogCateId")] string id, [FromBody] CreateBlogCategoryDto model)
        {
            _logger.LogInformation($"Begin {nameof(UpdateBlogCategory)} function in {this.GetType().Name}");
            try
            {
                var blogCateId = Guid.Parse(id);
                BlogCategoryEntity existedBlogCate = _blogCategoryRepo.FindById(blogCateId);
                if (existedBlogCate == null)
                {
                    _logger.LogError($"Not Load data of {nameof(UpdateBlogCategory)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
                }

                existedBlogCate.Id = blogCateId;
                existedBlogCate.BlogCategoryTitle = model.BlogCategoryTitle;
                existedBlogCate.DateOfModified = DateTime.Now;
                BlogCategoryEntity updatedBlogCate = _blogCateService.Update(existedBlogCate);
                if (updatedBlogCate != null)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateBlogCategory)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, updatedBlogCate));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateBlogCategory)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update Category is not successfully" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateBlogCategory)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("DeleteBlogCategory/{blogCateId}")]
        public async Task<IActionResult> DeleteBlogCategory([FromRoute(Name = "blogCateId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteBlogCategory)} function in {this.GetType().Name}");
            try
            {
                var blogCateId = Guid.Parse(id);
                BlogCategoryEntity existedBlogCate = _blogCategoryRepo.FindById(blogCateId);
                if (existedBlogCate == null)
                {
                    _logger.LogError($"Not Load data of {nameof(DeleteBlogCategory)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
                }
                bool isDeleted = _blogCateService.Delete(existedBlogCate);
                if (isDeleted)
                {
                    _logger.LogInformation($"Deleting data of {nameof(DeleteBlogCategory)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Blog Category is successfully!" }));
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteBlogCategory)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Blog Category is failed!" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteBlogCategory)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
