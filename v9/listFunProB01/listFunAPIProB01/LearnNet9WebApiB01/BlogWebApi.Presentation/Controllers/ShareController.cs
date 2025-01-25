using AutoMapper;
using BlogWebApi.Application.Repositories.BlogRepository;
using BlogWebApi.Application.Repositories.ShareEntityRepository;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
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
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Like with blog id {id}" }));
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
    }
}
