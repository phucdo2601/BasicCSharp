using AutoMapper;
using BlogWebApi.Application.Repositories.UserEntityRepository;
using BlogWebApi.Application.UnitOfWork;
using BlogWebApi.Domain.Dtos;
using BlogWebApi.Domain.Dtos.Authentications;
using BlogWebApi.Domain.Services.Users;
using BlogWebApi.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogWebApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AuthenticationController(ApplicationDbContext context, IUnitOfWork unitOfWork, ILogger<AuthenticationController> logger, IMapper mapper, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _userRepository = new UserRepository(_context);
            _userService = new UserService(_context, _unitOfWork, _userRepository);
            _logger = logger;
            _mapper = mapper;
            _appSettings = optionsMonitor.CurrentValue;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            _logger.LogInformation($"Begin {nameof(Login)} function in {this.GetType().Name}");

            var user = await _context.UserEntities.SingleOrDefaultAsync(p => p.Username == model.Username && p.Password == model.Password);
            if (user == null)
            {
               return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status404NotFound, Message = "Username or Password is invalid!" }));
            }
            var role = _unitOfWork.RoleRepository.FindByConditions(p => p.Id == user.RoleId).FirstOrDefault();

            // generate token;
            string dataToken = GenerateToken(user, role);

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                Message = "Login Successfully",
                Token = dataToken
            }));
        }

        private string GenerateToken(UserEntity user, RoleEntity role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescryption = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim("Username", user.Username),
                    new Claim("Id", user.Id.ToString()),

                    // roles
                    new Claim(ClaimTypes.Role, role.RoleTitle),


                    new Claim("TokenId", Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "YourIssuer",
                Audience = "YourAudience",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescryption);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
