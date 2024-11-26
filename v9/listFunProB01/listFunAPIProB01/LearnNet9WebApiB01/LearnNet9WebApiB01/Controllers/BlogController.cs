using AutoMapper;
using BlogWebApi.Application.Repositories.GenericRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Blogs;
using BlogWebApi.Domain.Services.BlogCategories;
using BlogWebApi.Domain.Services.Blogs;
using BlogWebApi.Domain.Services.Generics;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly IGenericRepository<BlogEntity> _blogRepo;
        private readonly IBlogService _blogService;
        private readonly ILogger<BlogController> _logger;
        private readonly IMapper _mapper;

        public BlogController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<BlogController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _blogRepo = new GenericRepository<BlogEntity>(_context);
            _blogService = new BlogService(_context, unitOfWork, _blogRepo);
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("getAllBlogs")]
        public async Task<IActionResult> GetAllBlog()
        {
            _logger.LogInformation($"Begin {nameof(GetAllBlog)} function in {this.GetType().Name}");
            var listBlogCate = _blogService.FindAll();
            if (listBlogCate.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listBlogCate));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllBlog)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Blogs" }));
        }

        [HttpGet("getBlogById/{blogId}")]
        public async Task<IActionResult> GetBlogById([FromRoute(Name = "blogId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetBlogById)} function in {this.GetType().Name}");
            try
            {
                var getBlogById = _blogService.FindById(Guid.Parse(id));
                if (getBlogById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetBlogById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getBlogById));
                }
                _logger.LogError($"Not Load data of {nameof(GetBlogById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetBlogById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }

        }

        [HttpPost("addNewBlog")]
        public async Task<IActionResult> AddNewBlog([FromBody] BlogCreateDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewBlog)} function in {this.GetType().Name}");
            if (model.Title == null)
            {
                _logger.LogError($"Not Load data of {nameof(AddNewBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The blog category title is not null" }));
            }
            var blogId = Guid.NewGuid();
            BlogEntity entity = _mapper.Map<BlogEntity>(model);
            entity.Id = blogId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _blogService.Create(entity);
            BlogEntity blogCate = _blogService.FindById(entity.Id);
            if (res > 0)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, blogCate));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewBlog)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));

        }

        [HttpPost("updateBlog/{blogId}")]
        public async Task<IActionResult> UpdateBlog([FromRoute(Name = "blogId")] string id, [FromBody] BlogCreateDto model)
        {
            _logger.LogInformation($"Begin {nameof(UpdateBlog)} function in {this.GetType().Name}");
            try
            {
                var blogCateId = Guid.Parse(id);
                BlogEntity existedBlog = _blogService.FindById(blogCateId);
                if (existedBlog == null)
                {
                    _logger.LogError($"Not Load data of {nameof(UpdateBlog)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
                }

                existedBlog.Id = blogCateId;
                existedBlog.Title = model.Title;
                existedBlog.DateOfModified = DateTime.Now;
                int updatedBlogCate = _blogService.Update(existedBlog);
                if (updatedBlogCate > 0)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateBlog)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, updatedBlogCate));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update Category is not successfully" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("deleteBlog/{blogId}")]
        public async Task<IActionResult> DeleteBlog([FromRoute(Name = "blogId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteBlog)} function in {this.GetType().Name}");
            try
            {
                var getBlogById = _blogService.FindById(Guid.Parse(id));
                if (getBlogById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(DeleteBlog)} function in {this.GetType().Name}");
                    bool isDeleted = _blogService.Delete(getBlogById);
                    if (isDeleted)
                    {
                        _logger.LogInformation($"Deleting data of {nameof(DeleteBlog)} function in {this.GetType().Name}");
                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Blog is successfully!" }));
                    }
                    _logger.LogError($"Not Deleting data of {nameof(DeleteBlog)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Blog is failed!" }));
                }
                _logger.LogError($"Not Load data of {nameof(DeleteBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteBlog)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}
