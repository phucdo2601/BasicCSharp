using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.LikeEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Likes;
using BlogWebApi.Domain.Services.Likes;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<LikeController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly ILikeService _likeService;

        public LikeController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<LikeController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userRepository = new UserRepository(_context);
            _blogRepository = new BlogRepository(_context);
            _likeRepository = new LikeRepository(_context);
            _likeService = new LikeService(_context, unitOfWork, _likeRepository);
        }

        [HttpGet("GetAllLikes")]
        public async Task<IActionResult> GetAllLikes()
        {
            _logger.LogInformation($"Begin {nameof(GetAllLikes)} function in {this.GetType().Name}");
            var listLikes = _likeService.FindAll();
            if (listLikes.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllLikes)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listLikes));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllLikes)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found all likes in the system" }));
        }

        [HttpGet("getLikeById/{likeId}")]
        public async Task<IActionResult> GetLikeById([FromRoute(Name = "likeId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetLikeById)} function in {this.GetType().Name}");
            try
            {
                var getLikeById = _likeService.FindById(Guid.Parse(id));
                if (getLikeById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getLikeById));
                }
                _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListLikesByUserId/{userId}")]
        public async Task<IActionResult> FindListLikeByUserId([FromRoute(Name = "userId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListLikeByUserId)} function in {this.GetType().Name}");
            try
            {
                var user = _userRepository.FindById(Guid.Parse(id));
                if (user == null)
                {
                    _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {id}" }));
                }
                else
                {
                    var getLikeByUserId = _likeService.FindByConditions(e => e.UserId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListLikeByUserId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getLikeByUserId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListLikesByBlogId/{blogId}")]
        public async Task<IActionResult> FindListLikeByBlogId([FromRoute(Name = "blogId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListLikeByBlogId)} function in {this.GetType().Name}");
            try
            {
                var blog = _blogRepository.FindById(Guid.Parse(id));
                if (blog == null)
                {
                    _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {id}" }));
                }
                else
                {
                    var getLikeByBlogId = _likeService.FindByConditions(e => e.BlogId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListLikeByBlogId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getLikeByBlogId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListLikeByUserIdAndBlogId")]
        public async Task<IActionResult> FindListLikeByUserIdAndBlogId([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "blogId")] string blogId)
        {
            _logger.LogInformation($"Begin {nameof(FindListLikeByUserIdAndBlogId)} function in {this.GetType().Name}");
            UserEntity user;
            BlogEntity blog;
            IEnumerable<LikeEntity> like;

            try
            {
                user = _userRepository.FindById(Guid.Parse(userId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {userId} is not valid! of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {userId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(Guid.Parse(blogId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {userId} is not valid! of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {blogId} is not valid!" }));
            }
            if (user == null && blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId} and user id {userId}" }));
            }

            if (user == null)
            {
                _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {userId}" }));
            }
            if (blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(GetLikeById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId}" }));
            }
            like = _likeService.FindByConditions(e => e.UserId == Guid.Parse(userId) && e.BlogId == Guid.Parse(blogId));
            _logger.LogInformation($"Loading data of {nameof(FindListLikeByUserId)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, like));
        }

        [HttpPost("addNewLike")]
        public async Task<IActionResult> AddNewLike([FromBody] CreateLikeDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewLike)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewLike)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }
            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewLike)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }

            var user = _userRepository.FindById(model.UserId);
            if (user == null)
            {
                _logger.LogError($"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(UserEntity)} by id {model.UserId.ToString()}" }));
            }

            var blog = _blogRepository.FindById(model.BlogId);
            if (blog == null)
            {
                _logger.LogError($"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found {nameof(BlogEntity)} by id {model.BlogId.ToString()}" }));
            }

            var likeId = new Guid();
            LikeEntity entity = _mapper.Map<LikeEntity>(model);
            entity.Id = likeId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _likeService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewLike)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewLike)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Create {nameof(LikeEntity)} is not successfully" }));

        }

        [HttpDelete("deleteLike/{likeId}")]
        public async Task<IActionResult> DeleteLike([FromRoute(Name = "likeId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteLike)} function in {this.GetType().Name}");
            try
            {
                var getLikeById = _likeRepository.FindById(Guid.Parse(id));
                if (getLikeById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(DeleteLike)} function in {this.GetType().Name}");
                    bool isDeleted = _likeService.Delete(getLikeById);
                    if (isDeleted)
                    {
                        _logger.LogInformation($"Deleting data of {nameof(DeleteLike)} function in {this.GetType().Name}");
                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Like is successfully!" }));
                    }
                    _logger.LogError($"Not Deleting data of {nameof(DeleteLike)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Like is failed!" }));
                }
                _logger.LogError($"Not Load data of {nameof(DeleteLike)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteLike)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }
    }
}