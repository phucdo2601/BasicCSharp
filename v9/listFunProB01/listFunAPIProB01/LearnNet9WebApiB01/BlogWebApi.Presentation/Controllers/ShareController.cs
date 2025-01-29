using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.ShareEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Shares;
using BlogWebApi.Domain.Services.Shares;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShareController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IShareRepository _shareRepository;
        private readonly IShareService _shareService;

        public ShareController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<ShareController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _userRepository = new UserRepository(_context);
            _blogRepository = new BlogRepository(_context);
            _shareRepository = new ShareRepository(_context);
            _shareService = new ShareService(_context, unitOfWork, _shareRepository);
        }

        [HttpGet("GetAllShares")]
        public async Task<IActionResult> GetAllShares()
        {
            _logger.LogInformation($"Begin {nameof(GetAllShares)} function in {this.GetType().Name}");
            var listShares = _shareService.FindAll();
            if (listShares.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllShares)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listShares));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllShares)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found all shares in the system" }));
        }

        [HttpGet("getShareById/{shareId}")]
        public async Task<IActionResult> GetShareById([FromRoute(Name = "shareId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetShareById)} function in {this.GetType().Name}");
            try
            {
                var getShareById = _shareService.FindById(Guid.Parse(id));
                if (getShareById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetShareById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getShareById));
                }
                _logger.LogError($"Not Load data of {nameof(GetShareById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Share with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetShareById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("GetListLikesByUserId/{userId}")]
        public async Task<IActionResult> FindListShareByUserId([FromRoute(Name = "userId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListShareByUserId)} function in {this.GetType().Name}");
            try
            {
                var user = _userRepository.FindById(Guid.Parse(id));
                if (user == null)
                {
                    _logger.LogError($"Not Load data of {nameof(FindListShareByUserId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {id}" }));
                }
                else
                {
                    var getShareByUserId = _shareService.FindByConditions(e => e.UserId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListShareByUserId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getShareByUserId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(FindListShareByUserId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListSharesByBlogId/{blogId}")]
        public async Task<IActionResult> FindListShareByBlogId([FromRoute(Name = "blogId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(FindListShareByBlogId)} function in {this.GetType().Name}");
            try
            {
                var blog = _blogRepository.FindById(Guid.Parse(id));
                if (blog == null)
                {
                    _logger.LogError($"Not Load data of {nameof(FindListShareByBlogId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Share with blog id {id}" }));
                }
                else
                {
                    var getListShareByBlogId = _shareService.FindByConditions(e => e.BlogId == Guid.Parse(id));
                    _logger.LogInformation($"Loading data of {nameof(FindListShareByBlogId)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getListShareByBlogId));
                }
            }
            catch (Exception)
            {
                _logger.LogError($"User ID {id} is not valid! of {nameof(FindListShareByBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpGet("getListShareByUserIdAndBlogId")]
        public async Task<IActionResult> FindListShareByUserIdAndBlogId([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "blogId")] string blogId)
        {
            _logger.LogInformation($"Begin {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
            UserEntity user;
            BlogEntity blog;
            IEnumerable<ShareEntity> listShare;

            try
            {
                user = _userRepository.FindById(Guid.Parse(userId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {userId} is not valid! of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"User ID {userId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(Guid.Parse(blogId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"Blog ID {userId} is not valid! of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Blog ID {blogId} is not valid!" }));
            }

            if (user == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {userId}" }));
            }
            if (blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId}" }));
            }

            if (user == null && blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId} and user id {userId}" }));
            }

            listShare = _shareService.FindByConditions(e => e.UserId == Guid.Parse(userId) && e.BlogId == Guid.Parse(blogId));
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, listShare }));
        }

        [HttpPost("addNewShare")]
        public async Task<IActionResult> AddNewShare([FromBody] CreateShareDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewShare)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(model.UserId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.UserId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewShare)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"The {nameof(model.UserId)} is not null" }));
            }
            if (string.IsNullOrWhiteSpace(model.BlogId.ToString()))
            {
                _logger.LogError($"The property {nameof(model.BlogId)} is null or empty or whitespace in {nameof(model)} of {nameof(AddNewShare)} function in {this.GetType().Name}");
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

            var shareId = new Guid();
            ShareEntity entity = _mapper.Map<ShareEntity>(model);
            entity.Id = shareId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _shareService.Create(entity);
            if (res != null)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewShare)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, res));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewShare)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Create {nameof(LikeEntity)} is not successfully" }));
        }

        [HttpDelete("deleteShareById/{shareId}")]
        public async Task<IActionResult> DeleteShareById([FromRoute(Name = "shareId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteShareById)} function in {this.GetType().Name}");
            try
            {
                var getLikeById = _shareRepository.FindById(Guid.Parse(id));
                if (getLikeById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                    bool isDeleted = _shareService.Delete(getLikeById);
                    if (isDeleted)
                    {
                        _logger.LogInformation($"Deleting data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Like is successfully!" }));
                    }
                    _logger.LogError($"Not Deleting data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Like is failed!" }));
                }
                _logger.LogError($"Not Load data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("DeleteShareByIdAndUserIdAndBlogId")]
        public async Task<IActionResult> DeleteShareByShareByIdAndUserIdAndBlogId([FromQuery(Name = "shareId")] string shareId, [FromQuery(Name = "userId")] string userId, [FromQuery(Name = "blogId")] string blogId)
        {
            _logger.LogInformation($"Begin {nameof(DeleteShareByShareByIdAndUserIdAndBlogId)} function in {this.GetType().Name}");
            UserEntity user;
            BlogEntity blog;
            ShareEntity share;

            try
            {
                user = _userRepository.FindById(Guid.Parse(userId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"User ID {userId} is not valid! of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"User ID {userId} is not valid!" }));
            }

            try
            {
                blog = _blogRepository.FindById(Guid.Parse(blogId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"Blog ID {blogId} is not valid! of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Blog ID {blogId} is not valid!" }));
            }

            try
            {
                share = _shareRepository.FindById(Guid.Parse(shareId));
            }
            catch (System.Exception)
            {
                _logger.LogError($"Share ID {shareId} is not valid! of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"Blog ID {shareId} is not valid!" }));
            }

            if (user == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with user id {userId}" }));
            }
            else if (blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {blogId}" }));
            }
            else if (share == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Share with share id {share}" }));
            }
            else if (share == null && user == null && blog == null)
            {
                _logger.LogError($"Not Load data of {nameof(FindListShareByUserIdAndBlogId)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with share id {shareId} and blog id {blogId} and user id {userId}" }));
            }
            else
            {
                var getShareByIAndUserIdAndBlogId = _shareRepository.FindByConditions(e => e.Id == Guid.Parse(shareId) && e.UserId == Guid.Parse(userId) && e.BlogId == Guid.Parse(blogId)).FirstOrDefault();
                if (getShareByIAndUserIdAndBlogId != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                    bool isDeleted = _shareService.Delete(getShareByIAndUserIdAndBlogId);
                    if (isDeleted)
                    {
                        _logger.LogInformation($"Deleting data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete Like is successfully!" }));
                    }
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteShareById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete Like is failed!" }));
            }
        }
    }
}
