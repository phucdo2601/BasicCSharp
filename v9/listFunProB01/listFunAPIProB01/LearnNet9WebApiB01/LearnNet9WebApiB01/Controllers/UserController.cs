using AutoMapper;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos.Users;
using BlogWebApi.Domain.Services.Users;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepo;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<UserController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userRepo = new UserRepository(context);
            _userService = new UserService(_context, _unitOfWork, _userRepo);
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation($"Begin {nameof(GetAllUsers)} function in {this.GetType().Name}");
            var listUsers = _userService.FindAll();
            if (listUsers.ToList().Count >= 0)
            {
                _logger.LogInformation($"Loading list data of {nameof(GetAllUsers)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listUsers));
            }
            _logger.LogError($"Not Load list data of {nameof(GetAllUsers)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Not Found Blogs" }));
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute(Name = "userId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(GetUserById)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetUserById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespa" }));
            }
            try
            {
                var getUserById = _userService.FindById(Guid.Parse(id));
                if (getUserById != null)
                {
                    _logger.LogInformation($"Loading data of {nameof(GetUserById)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, getUserById));
                }
                _logger.LogError($"Not Load data of {nameof(GetUserById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found Blog Category with id {id}" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(GetUserById)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser([FromBody] CreateUserDto model)
        {
            _logger.LogInformation($"Begin {nameof(AddNewUser)} function in {this.GetType().Name}");
            if (!ModelState.IsValid)
            {
                // Return validation errors
                return BadRequest(ModelState);
            }
            var userId = Guid.NewGuid();
            UserEntity entity = _mapper.Map<UserEntity>(model);
            entity.Id = userId;
            entity.DateOfCreated = DateTime.UtcNow;
            entity.DateOfModified = DateTime.UtcNow;
            var res = _userService.Create(entity);
            UserEntity user = _userService.FindById(userId);
            if (res > 0)
            {
                _logger.LogInformation($"Adding data of {nameof(AddNewUser)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, user));
            }
            _logger.LogError($"Not Adding data of {nameof(AddNewUser)} function in {this.GetType().Name}");
            return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create User is not successfully" }));
        }

        [HttpPut("UpdateBlogCategory/{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute(Name = "userId")] string id, UpdateUserDto model)
        {
            _logger.LogInformation($"Begin {nameof(UpdateUser)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetUserById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespa" }));
            }
            try
            {
                var userId = Guid.NewGuid();
                UserEntity existedUser = _userService.FindById(userId);
                if (existedUser == null)
                {
                    _logger.LogError($"Not Load data of {nameof(UpdateUser)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found User with id {id}" }));
                }

                existedUser = _mapper.Map<UserEntity>(model);
                existedUser.DateOfModified = DateTime.UtcNow;
                int updatedUser = _userService.Update(existedUser);
                if (updatedUser > 0)
                {
                    _logger.LogInformation($"Updating data of {nameof(UpdateUser)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, existedUser));
                }
                _logger.LogError($"Not Updating data of {nameof(UpdateUser)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Update User is not successfully" }));
            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateUser)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute(Name = "userId")] string id)
        {
            _logger.LogInformation($"Begin {nameof(DeleteUser)} function in {this.GetType().Name}");
            if (string.IsNullOrWhiteSpace(id))
            {
                _logger.LogError($"Id params of {nameof(GetUserById)} function in {this.GetType().Name} is null.");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Id params is not null or blank or whitespa" }));
            }
            try
            {
                var userId = Guid.Parse(id);
                UserEntity existedUser = _userService.FindById(userId);
                if (existedUser == null)
                {
                    _logger.LogError($"Not Load data of {nameof(DeleteUser)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Not Found user with id {id}" }));
                }
                bool isDeleted = _userService.Delete(existedUser);
                if (isDeleted)
                {
                    _logger.LogInformation($"Deleting data of {nameof(DeleteUser)} function in {this.GetType().Name}");
                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new { StatusCode = StatusCodes.Status200OK, Message = $"Delete user is successfully!" }));
                }
                _logger.LogError($"Not Deleting data of {nameof(DeleteUser)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = $"Delete user is failed!" }));

            }
            catch (Exception)
            {
                _logger.LogError($"ID {id} is not valid! of {nameof(UpdateUser)} function in {this.GetType().Name}");
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"ID {id} is not valid!" }));
            }

        }
    }
}
